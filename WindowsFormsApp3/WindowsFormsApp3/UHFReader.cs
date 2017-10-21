using ModuleLibrary;
using ModuleTech;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace WindowsFormsApp3
{
    public class UHFReader
    {
        private Reader modulerdr;
        private string readerCom;
        private int readerPower;

        public UHFReader(string readerCom,int readerPower)
        {
            InitReader(readerCom, readerPower);
        }

        private void InitReader(string readerCom, int readerPower)
        {
            this.readerCom = readerCom;
            this.readerPower = readerPower;
            if (readerPower > 1900)
            {
                readerPower = 1900;
            }
            modulerdr = Reader.Create(readerCom, ModuleTech.Region.NA, 1);
            modulerdr.ParamSet("ReadPlan", new SimpleReadPlan(TagProtocol.GEN2, new int[] { 1 }));
            modulerdr.ParamSet("TagopAntenna", 1);
            modulerdr.ParamSet("ReadTxPower", readerPower);

        }

        public string writeTag(string epc)
        {
            
            try
            {
                modulerdr = Reader.Create(readerCom, ModuleTech.Region.NA, 1);
                modulerdr.ParamSet("ReadPlan", new SimpleReadPlan(TagProtocol.GEN2, new int[] { 1 }));
                modulerdr.ParamSet("TagopAntenna", 1);
                modulerdr.ParamSet("ReadTxPower", readerPower);
                TagData epccode = new TagData(epc);
                modulerdr.WriteTag(null, epccode);
                modulerdr.Disconnect();
                return "success";
            }
            catch (OpFaidedException e)
            {
                modulerdr.Disconnect();
                Console.WriteLine(e.Message);
                return "OpFaidedException";
            }
            catch (ModuleException)
            {
                return "ModuleException";
            }
        }

        public void disConnect()
        {
            modulerdr.Disconnect();
        }

        public string readEPC()
        {
            
            string epc = "";
            try
            {
                
                TagReadData[] reads = modulerdr.Read(50);
                int maxCount = 0;

                if (reads != null && reads.Length > 0)                
                {
                    for (int i = 0; i < reads.Length; i++)
                    {
                        if(reads[i].ReadCount > maxCount)
                        {
                            maxCount = reads[i].ReadCount;
                            epc = reads[i].EPCString;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("没有读到标签");
                }

                
                return epc;
            }
            catch (OpFaidedException)
            {
                modulerdr.Disconnect();
                return "OpFaidedException";
            }
            catch (ModuleException)
            {
                return "ModuleException";
            }
        }
    }
}
