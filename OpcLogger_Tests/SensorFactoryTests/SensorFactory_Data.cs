namespace OpcLogger_Tests.SensorFactoryTests
{
    public partial class SensorFactory_Tests
    {
        private readonly string xml =
            @"<Header>
                  <Channel name=""SET.KTP-14."" id=""1"">
                    <Tag id_log=""1"" OPC_Tag=""ns=2;s=SET.KTP-14.Ia"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""2"" OPC_Tag=""ns=2;s=SET.KTP-14.Ib"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""3"" OPC_Tag=""ns=2;s=SET.KTP-14.Ic"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""4"" OPC_Tag=""ns=2;s=SET.KTP-14.Ua"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""5"" OPC_Tag=""ns=2;s=SET.KTP-14.Ub"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""6"" OPC_Tag=""ns=2;s=SET.KTP-14.Uc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""7"" OPC_Tag=""ns=2;s=SET.KTP-14.Uab"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""8"" OPC_Tag=""ns=2;s=SET.KTP-14.Ubc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""9"" OPC_Tag=""ns=2;s=SET.KTP-14.Uca"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""10"" OPC_Tag=""ns=2;s=SET.KTP-14.Pa"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""11"" OPC_Tag=""ns=2;s=SET.KTP-14.Pb"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""12"" OPC_Tag=""ns=2;s=SET.KTP-14.Pc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""13"" OPC_Tag=""ns=2;s=SET.KTP-14.Psum"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""14"" OPC_Tag=""ns=2;s=SET.KTP-14.Qa"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""15"" OPC_Tag=""ns=2;s=SET.KTP-14.Qb"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""16"" OPC_Tag=""ns=2;s=SET.KTP-14.Qc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""17"" OPC_Tag=""ns=2;s=SET.KTP-14.Qsum"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""18"" OPC_Tag=""ns=2;s=SET.KTP-14.Sa"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""19"" OPC_Tag=""ns=2;s=SET.KTP-14.Sb"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""20"" OPC_Tag=""ns=2;s=SET.KTP-14.Sc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""21"" OPC_Tag=""ns=2;s=SET.KTP-14.Ssum"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""22"" OPC_Tag=""ns=2;s=SET.KTP-14.Cos_a"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""23"" OPC_Tag=""ns=2;s=SET.KTP-14.Cos_b"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""24"" OPC_Tag=""ns=2;s=SET.KTP-14.Cos_c"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""25"" OPC_Tag=""ns=2;s=SET.KTP-14.Cos_f"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""27"" OPC_Tag=""ns=2;s=SET.KTP-14.Connect"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""595"" OPC_Tag=""ns=2;s=SET.KTP-14.Tarif_Summ"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""617"" OPC_Tag=""ns=2;s=_AdvancedTags.SET.KTP-14.Isr"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""639"" OPC_Tag=""ns=2;s=_AdvancedTags.SET.KTP-14.Usr"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""661"" OPC_Tag=""ns=2;s=_AdvancedTags.SET.KTP-14.Ufsr"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                  </Channel>
                  <Channel name=""SET.KTP-45."" id=""3"">
                    <Tag id_log=""55"" OPC_Tag=""ns=2;s=SET.KTP-45.Ia"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""56"" OPC_Tag=""ns=2;s=SET.KTP-45.Ib"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""57"" OPC_Tag=""ns=2;s=SET.KTP-45.Ic"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""58"" OPC_Tag=""ns=2;s=SET.KTP-45.Ua"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""59"" OPC_Tag=""ns=2;s=SET.KTP-45.Ub"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""60"" OPC_Tag=""ns=2;s=SET.KTP-45.Uc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""61"" OPC_Tag=""ns=2;s=SET.KTP-45.Uab"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""62"" OPC_Tag=""ns=2;s=SET.KTP-45.Ubc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""63"" OPC_Tag=""ns=2;s=SET.KTP-45.Uca"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""64"" OPC_Tag=""ns=2;s=SET.KTP-45.Pa"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""65"" OPC_Tag=""ns=2;s=SET.KTP-45.Pb"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""66"" OPC_Tag=""ns=2;s=SET.KTP-45.Pc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""67"" OPC_Tag=""ns=2;s=SET.KTP-45.Psum"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""68"" OPC_Tag=""ns=2;s=SET.KTP-45.Qa"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""69"" OPC_Tag=""ns=2;s=SET.KTP-45.Qb"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""70"" OPC_Tag=""ns=2;s=SET.KTP-45.Qc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""71"" OPC_Tag=""ns=2;s=SET.KTP-45.Qsum"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""72"" OPC_Tag=""ns=2;s=SET.KTP-45.Sa"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""73"" OPC_Tag=""ns=2;s=SET.KTP-45.Sb"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""74"" OPC_Tag=""ns=2;s=SET.KTP-45.Sc"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""75"" OPC_Tag=""ns=2;s=SET.KTP-45.Ssum"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""76"" OPC_Tag=""ns=2;s=SET.KTP-45.Cos_a"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""77"" OPC_Tag=""ns=2;s=SET.KTP-45.Cos_b"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""78"" OPC_Tag=""ns=2;s=SET.KTP-45.Cos_c"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""79"" OPC_Tag=""ns=2;s=SET.KTP-45.Cos_f"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""81"" OPC_Tag=""ns=2;s=SET.KTP-45.Connect"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""597"" OPC_Tag=""ns=2;s=SET.KTP-45.Tarif_Summ"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""619"" OPC_Tag=""ns=2;s=_AdvancedTags.SET.KTP-45.Isr"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""641"" OPC_Tag=""ns=2;s=_AdvancedTags.SET.KTP-45.Usr"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                    <Tag id_log=""663"" OPC_Tag=""ns=2;s=_AdvancedTags.SET.KTP-45.Ufsr"">
                      <Condition Type=""TimeSpan"" Value=""5"" />
                    </Tag>
                  </Channel>
              </Header>";
    }
}
