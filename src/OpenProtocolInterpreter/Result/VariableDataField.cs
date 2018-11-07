using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Result
{
    public class VariableDataField
    {
        public int ParameterId { get; set; }
        public int Length { get; set; }
        public int DataType { get; set; }
        public int Unit { get; set; }
        public int StepNumber { get; set; }
        public string RealValue { get; set; }

        public VPID GetEnum()
        {
            VPID myPID = VPID.UNKNOWN;

            try
            {
                myPID = (VPID)ParameterId;
            }
            catch (Exception)
            {

            }
            return myPID;
        }

        private string GetName(int _paramID)
        {
            VPID myPIDResult = VPID.Results_Identifier;
            bool ok = Enum.TryParse<VPID>(_paramID.ToString(), out myPIDResult);
            if (!ok)
            {
                return "UNKNOWN";
            }
            return myPIDResult.ToString(); ;
        }

        public string buildPackage()
        {
            string pack = "";
            pack += this.ParameterId.ToString().PadLeft(fields[(int)DataFields.PARAM_ID].Size, '0');
            pack += this.Length.ToString().PadLeft(fields[(int)DataFields.LENGTH].Size, '0');
            pack += this.DataType.ToString().PadLeft(fields[(int)DataFields.DATA_TYPE].Size, '0');
            pack += this.Unit.ToString().PadLeft(fields[(int)DataFields.UNIT].Size, '0');
            pack += this.StepNumber.ToString().PadLeft(fields[(int)DataFields.STEP_NO].Size, '0');

            pack += this.RealValue.ToString().PadRight(fields[(int)DataFields.PARAM_VALUE].Size, ' ');
            return pack;

        }
        private void registerDatafields()
        {
            this.fields.AddRange(
               new DataField[]
               {
               new DataField((int)DataFields.PARAM_ID,0, 5),
               new DataField((int)DataFields.LENGTH, 5, 3),
               new DataField((int)DataFields.DATA_TYPE, 8, 2),
               new DataField((int)DataFields.UNIT, 10, 3),
               new DataField((int)DataFields.STEP_NO, 13, 4),
               new DataField((int)DataFields.PARAM_VALUE, 17, 1),

               });
        }


        private VariableDataField getObjectDataFromPackage(string package, out int lenUsed)
        {
            VariableDataField VarDataField = new VariableDataField();

            // need at least 18 long.
            if (package.Length < 18)
            {

            }
            try
            {
                foreach (DataField field in VarDataField.fields)
                {
                    field.Value = package.Substring(field.Index, field.Size);
                }

                VarDataField.ParameterId = VarDataField.fields[(int)DataFields.PARAM_ID].ToInt32();
                VarDataField.Length = VarDataField.fields[(int)DataFields.LENGTH].ToInt32();
                VarDataField.DataType = VarDataField.fields[(int)DataFields.DATA_TYPE].ToInt32();
                VarDataField.Unit = VarDataField.fields[(int)DataFields.UNIT].ToInt32();
                VarDataField.StepNumber = VarDataField.fields[(int)DataFields.STEP_NO].ToInt32();


                VarDataField.fields[(int)DataFields.PARAM_VALUE].Size = VarDataField.Length;
                VarDataField.fields[(int)DataFields.PARAM_VALUE].Value = package.Substring(VarDataField.fields[(int)DataFields.PARAM_VALUE].Index, VarDataField.fields[(int)DataFields.PARAM_VALUE].Size);
                VarDataField.RealValue = VarDataField.fields[(int)DataFields.PARAM_VALUE].ToString();
            }
            catch (Exception)
            {

            }

            lenUsed = 17 + VarDataField.Length;
            return VarDataField;
        }

        public enum DataFields
        {
            PARAM_ID,
            LENGTH,
            DATA_TYPE,
            UNIT,
            STEP_NO,
            PARAM_VALUE,
        }

        public IEnumerable<VariableDataField> GetBVarDataFieldsFromPackage(int totalObjects, string package)
        {
            List<VariableDataField> obj = new List<VariableDataField>();
            // we are parsing a packeg of just the correct size and break into seperate items and build up a list.
            try
            {
                for (int i = 0; i < totalObjects; i++)
                {
                    int lenUsed = 0;
                    VariableDataField var1 = this.getObjectDataFromPackage(package, out lenUsed);
                    obj.Add(var1);
                    package = package.Substring(lenUsed); // or do i add 1 ??
                }
            }
            catch (Exception)
            {

            }
            return obj;
        }




    }
}
