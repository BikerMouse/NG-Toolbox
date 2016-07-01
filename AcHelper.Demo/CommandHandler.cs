﻿using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Windows.Input;
using AcHelper.Command;
using Autodesk.AutoCAD.Geometry;
using AcHelper.Demo.Commands;

namespace AcHelper.Demo
{
    public class CommandHandler : CommandHandlerBase
    {
        [CommandMethod("DEMO_HELP")]
        public static void Demo_Help()
        {
            Active.WriteMessage("\n=========================================");
            Active.WriteMessage("\nWelcome to the AcHelper Demo for AutoCAD");
            Active.WriteMessage("\nThe next commands are available:");
            Active.WriteMessage("\n\t- DEMO_DRAWCIRCLE");
            Active.WriteMessage("\n\t- DEMO_ADDXRECORD");
            Active.WriteMessage("\n=========================================\n");
        }

        [CommandMethod("DEMO_DRAWCIRCLE")]
        public static void Demo_DrawCircle()
        {
            ExecuteCommand<CreateCircle>();
        }
        [CommandMethod("DEMO_THROWERROR")]
        public static void Demo_ThrowError()
        {
            ExecuteCommand<ThrowErrorCommand>();
        }

        [CommandMethod("DEMO_ADDXRECORDTOENTITY")]
        public static void Demo_AddXrecordToEntity()
        {
            Editor ed = Active.Editor;
            try
            {
                PromptEntityOptions opt = new PromptEntityOptions("\nSelect an entity to add xRecord");
                PromptEntityResult res = ed.GetEntity(opt);
                if (res.Status == PromptStatus.OK)
                {
                    ObjectId oid = res.ObjectId;
                    ResultBuffer resbuf = new ResultBuffer();
                    resbuf.Add(new TypedValue((int)DxfCode.Text, "Hello AutoCAD MAP 3D"));
                    Utilities.SetXrecord(oid, "DEMO_XRECORD", resbuf);
                }
                //Utilities.AddTextDataToEntity("DEMO_XRECORD", "Hello AutoCAD MAP 3D");
            }
            catch (System.Exception ex)
            {
                Active.WriteMessage(ex.Message);
                if (ex.InnerException != null)
                {
                    Active.WriteMessage(ex.InnerException.Message);
                }
            }

            try
            {
                Utilities.AddXrecordToDocument("DEMO_NOD", "DEMO_KEY", "Hello AutoCAD");
            }
            catch (System.Exception ex)
            {
                Active.WriteMessage(ex.Message);
                if (ex.InnerException != null)
                {
                    Active.WriteMessage(ex.InnerException.Message);
                }
            }
        }

        [CommandMethod("DEMO_DISPLAYDOCUMENTXRECORD")]
        public static void DisplayDocumentXrecord()
        {
            try
            {
                Utilities.DisplayDocumentXrecord("DEMO_NOD","DEMO_KEY");
            }
            catch (System.Exception ex)
            {
                Active.WriteMessage(ex.Message);
                if (ex.InnerException != null)
                {
                    Active.WriteMessage(ex.InnerException.Message);
                }
            }
        }
    }
}
