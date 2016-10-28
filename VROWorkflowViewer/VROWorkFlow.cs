using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace VROWorkflowViewer
{
    public class VROWorkFlow
    {
        public class Variables
        {
            public String name;
            public String variableType;
            public Boolean isAttribute;
            public Boolean isReadOnly;
            public String value;

            public override String ToString()
            {
                if (isAttribute)
                {
                    return "Attribute : " + name + " Type : " + variableType + " Default : " + value;
                }
                else
                {
                    return "Name : " + name + " Type : " + variableType;
                }
            }
        }

        public String errorMessage;
        public class WorkFlowItem
        {
            public String displayName;
            public String itemName;
            public String outItemName;
            public String outDisplayName;
            public String altOutItemName;
            public String altOutDisplayName;
            public String scriptModule;
            public String catchName;
            public String throwBindName;
            public String comparator;
            public String wfiType;
            public String endMode;
            public String[] lines;
            public Dictionary<String, Variables> inputs;
            public Dictionary<String, Variables> outputs;

            public WorkFlowItem()
            {
                inputs = new Dictionary<string, Variables>();
                outputs = new Dictionary<string, Variables>();
            }


            public override String ToString()
            {
                String rData = "WFI : " + displayName + " Item : " + itemName + " Next : " + outDisplayName + " (" + outItemName + ") Type : " + wfiType;
                if (altOutItemName != null) rData += " AltOut : " + altOutDisplayName + " (" + altOutItemName + ")";
                if (catchName != null) rData += " Catch : " + catchName;
                if (throwBindName != null) rData += " ThrowBind : " + throwBindName;
                if (scriptModule != null) rData += " ScriptModule : " + scriptModule;
                if (comparator != null) rData += " Comparator : " + comparator;
                if (endMode != null) rData += " EndMode : " + endMode;
                return rData;
            }
        }
        public String rootItem;        
        public Dictionary<String,Variables> inputs;
        public Dictionary<String,Variables> attribs;

        public Dictionary<String, WorkFlowItem> workitems;
        public Dictionary<String, String> itemKeys;

        public VROWorkFlow()
        {
            InitData();
        }

        private const String cdata = "<![CDATA[";
        private String StripCDATA(String data)
        {
            if (data.StartsWith(cdata))
            {
                return data.Substring(cdata.Length, data.Length - cdata.Length - 3);
            }
            else
                return cdata;
        }

        public VROWorkFlow(String filename)
        {
            InitData();
            if (File.Exists(filename))
                ParseWorkFlow(File.ReadAllText(filename));
            else
                throw new FileNotFoundException("WorkFlow Not Found", filename);
        }
       

        private void InitData()
        {
            workitems = new Dictionary<String,WorkFlowItem>();
            itemKeys = new Dictionary<string, string>();
            inputs = new Dictionary<string, Variables>();
            attribs = new Dictionary<string, Variables>();
        }

        public Boolean ParseWorkFlow(String datalines)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(datalines);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }            
            
            foreach (XmlNode topNode in xmlDoc.ChildNodes)
            {
                switch (topNode.Name)
                {
                    case "workflow":
                        foreach (XmlAttribute attrib in topNode.Attributes)
                        {
                            switch (attrib.Name)
                            {
                                case "root-name":
                                    rootItem = attrib.Value;
                                    break;
                            }
                        }
                        foreach (XmlNode wfNode in topNode.ChildNodes)
                        {
                        
                            switch (wfNode.Name)
                            {
                                case "display-name":
                                    ParseDisplayName(wfNode);
                                    break;
                                case "input":
                                    ParseInput(wfNode);
                                    break;
                                case "attrib":
                                    ParseAttrib(wfNode);
                                    break;
                                case "workflow-item":
                                    ParseWFItem(wfNode);
                                    break;
                                default:
                                    System.Diagnostics.Debug.Print("XML Node : " + wfNode.Name);
                                    break;

                            }
                        }
                        break;                        
                }
            }
         
            // Adjust the Output and AltOut Display Names

            foreach (WorkFlowItem wfi in workitems.Values)
            {
                if (wfi.outItemName != null) wfi.outDisplayName = workitems[wfi.outItemName].displayName;
                if (wfi.altOutItemName != null) wfi.altOutDisplayName = workitems[wfi.altOutItemName].displayName;
            }
            return true;
        }

        private void Log(String fmt,params Object[] parms)    
        {
            System.Diagnostics.Debug.Print(fmt, parms);
        }

        private void ParseDisplayName(XmlNode dname)
        {
            //Log("Display Name {0}", dname.InnerText);
        }

        private void ParseInput(XmlNode hNode)
        {
            foreach (XmlNode node in hNode.ChildNodes)
            {
                if (node.Name == "param")
                {
                    Variables iVar = new Variables();
                    foreach (XmlAttribute attrib in node.Attributes)
                    {
                        switch (attrib.Name)
                        {
                            case "name":
                                iVar.name = attrib.Value;
                                break;
                            case "type":
                                iVar.variableType = attrib.Value;
                                break;
                            default:
                                Log("New Input Attrib : {0} = {1}", attrib.Name, attrib.Value);
                                break;
                        }
                        
                    }
                    //Log("Input Variable : {0}", iVar.ToString());
                    inputs.Add(iVar.name,iVar);
                }
            }
        }
        private void ParseAttrib(XmlNode hNode)
        {
            Variables iVar = new Variables();
            iVar.isAttribute = true;
            foreach (XmlAttribute attrib in hNode.Attributes)
            {
                switch (attrib.Name)
                {
                    case "name":
                        iVar.name = attrib.Value;
                        break;
                    case "type":
                        iVar.variableType = attrib.Value;
                        break;
                    case "read-only":
                        iVar.isReadOnly = (attrib.Value == "false") ? false : true;
                        break;
                    default:
                        Log("New Input Attrib : {0} = {1}", attrib.Name, attrib.Value);
                        break;
                }
            }
            foreach (XmlNode node in hNode.ChildNodes)
            {
                switch (node.Name)
                {
                    case "value":
                        iVar.value = node.InnerText;
                        break;
                }
            }                         

            //Log("Attribute Variable : {0}", iVar.ToString());
            attribs.Add(iVar.name,iVar); 
        }

        private void ParseNote(XmlNode note)
        {
        }

        private void ParseWFItem(XmlNode hNode)
        {
            WorkFlowItem wfi = new WorkFlowItem();                        
            foreach (XmlAttribute attrib in hNode.Attributes)
            {
                switch (attrib.Name)
                {
                    case "name":
                        wfi.itemName = attrib.Value;
                        break;
                    case "out-name":
                        wfi.outItemName = attrib.Value;
                        break;
                    case "type":
                        wfi.wfiType = attrib.Value;
                        break;
                    case "alt-out-name":
                        wfi.altOutItemName = attrib.Value;
                        break;
                    case "comparator":
                        wfi.comparator = attrib.Value;
                        break;
                    case "script-module":
                        wfi.scriptModule = attrib.Value;
                        break;
                    case "throw-bind-name":
                        wfi.throwBindName = attrib.Value;
                        break;
                    case "catch-name":
                        wfi.catchName = attrib.Value;
                        break;
                    case "end-mode":
                        wfi.endMode = attrib.Value;
                        break;
                    default:
                        Log("New WFI Attrib : {0} = {1}", attrib.Name, attrib.Value);
                        break;
                }
            }
            foreach (XmlNode node in hNode.ChildNodes)
            {
                switch (node.Name)
                {
                    case "display-name":
                        wfi.displayName= node.InnerText;
                        break;
                    case "script":
                        wfi.lines = node.InnerText.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
                        break;
                    case "in-binding":
                        foreach (XmlNode bNode in node.ChildNodes)
                        {
                            if (bNode.Name == "bind")
                            {
                                String bindName = "";
                                String bindType = "";
                                String bindEName = "";
                                foreach (XmlAttribute bAttr in bNode.Attributes)
                                {
                                    switch (bAttr.Name)
                                    {
                                        case "name":
                                            bindName = bAttr.Value;
                                            break;
                                        case "type":
                                            bindType = bAttr.Value;
                                            break;
                                        case "export-name":
                                            bindEName = bAttr.Value;
                                            break;
                                    }
                                }
                                if (inputs.ContainsKey(bindEName))
                                {
                                    wfi.inputs.Add(bindName, inputs[bindEName]);
                                }
                                else if (attribs.ContainsKey(bindEName))
                                {
                                    wfi.inputs.Add(bindName, attribs[bindEName]);
                                }
                            }
                        }
                        break;
                    case "out-binding":
                        foreach (XmlNode bNode in node.ChildNodes)
                        {
                            if (bNode.Name == "bind")
                            {
                                String bindName = "";
                                String bindType = "";
                                String bindEName = "";
                                foreach (XmlAttribute bAttr in bNode.Attributes)
                                {
                                    switch (bAttr.Name)
                                    {
                                        case "name":
                                            bindName = bAttr.Value;
                                            break;
                                        case "type":
                                            bindType = bAttr.Value;
                                            break;
                                        case "export-name":
                                            bindEName = bAttr.Value;
                                            break;
                                    }
                                }
                                if (inputs.ContainsKey(bindEName))
                                {
                                    wfi.outputs.Add(bindName, inputs[bindEName]);
                                }
                                else if (attribs.ContainsKey(bindEName))
                                {
                                    wfi.outputs.Add(bindName, attribs[bindEName]);
                                }
                            }
                        }
                        break;                        
                }
            }
            String keyname = wfi.displayName + ":" + wfi.itemName;
            workitems.Add(wfi.itemName, wfi);
            itemKeys.Add(keyname, wfi.itemName);            
        }

        private void ParsePresentation(XmlNode presentation)
        {
        }

    }
}
