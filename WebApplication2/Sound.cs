
namespace SoundExample
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Sound
    {
        [JsonProperty("qualities")]
        public long[] Qualities { get; set; }

        [JsonProperty("pitch")]
        public long Pitch { get; set; }

        [JsonProperty("note")]
        public long Note { get; set; }

        [JsonProperty("instrument_source_str")]
        public InstrumentSourceStr InstrumentSourceStr { get; set; }

        [JsonProperty("velocity")]
        public long Velocity { get; set; }

        [JsonProperty("instrument_str")]
        public InstrumentStr InstrumentStr { get; set; }

        [JsonProperty("instrument")]
        public long Instrument { get; set; }

        [JsonProperty("sample_rate")]
        public long SampleRate { get; set; }

        [JsonProperty("qualities_str")]
        public QualitiesStr[] QualitiesStr { get; set; }

        [JsonProperty("instrument_source")]
        public long InstrumentSource { get; set; }

        [JsonProperty("note_str")]
        public string NoteStr { get; set; }

        [JsonProperty("instrument_family")]
        public long InstrumentFamily { get; set; }

        [JsonProperty("instrument_family_str")]
        public InstrumentFamilyStr InstrumentFamilyStr { get; set; }
    }

    public enum InstrumentFamilyStr { Bass, Brass, Flute, Guitar, Keyboard, Mallet, Organ, Reed, String, Vocal };

    public enum InstrumentSourceStr { Acoustic, Electronic, Synthetic };

    public enum InstrumentStr { BassElectronic018, BassElectronic025, BassElectronic027, BassSynthetic009, BassSynthetic033, BassSynthetic034, BassSynthetic068, BassSynthetic098, BassSynthetic134, BassSynthetic135, BrassAcoustic006, BrassAcoustic015, BrassAcoustic016, BrassAcoustic046, BrassAcoustic059, FluteAcoustic002, FluteSynthetic000, GuitarAcoustic010, GuitarAcoustic014, GuitarAcoustic015, GuitarAcoustic021, GuitarAcoustic030, GuitarElectronic022, GuitarElectronic028, KeyboardAcoustic004, KeyboardElectronic001, KeyboardElectronic002, KeyboardElectronic003, KeyboardElectronic069, KeyboardElectronic078, KeyboardElectronic098, KeyboardSynthetic000, MalletAcoustic047, MalletAcoustic056, MalletAcoustic062, OrganElectronic001, OrganElectronic007, OrganElectronic028, OrganElectronic057, OrganElectronic104, OrganElectronic113, ReedAcoustic011, ReedAcoustic018, ReedAcoustic023, ReedAcoustic037, StringAcoustic012, StringAcoustic014, StringAcoustic056, StringAcoustic057, StringAcoustic071, StringAcoustic080, VocalAcoustic000, VocalSynthetic003 };

    public enum QualitiesStr { Bright, Dark, Distortion, FastDecay, LongRelease, Multiphonic, NonlinearEnv, Percussive, Reverb, TempoSynced };

    public partial class Sound
    {
        public static Dictionary<string, Sound> FromJson(string json) => JsonConvert.DeserializeObject<Dictionary<string, Sound>>(json, SoundExample.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Dictionary<string, Sound> self) => JsonConvert.SerializeObject(self, SoundExample.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                InstrumentFamilyStrConverter.Singleton,
                InstrumentSourceStrConverter.Singleton,
                InstrumentStrConverter.Singleton,
                QualitiesStrConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class InstrumentFamilyStrConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InstrumentFamilyStr) || t == typeof(InstrumentFamilyStr?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bass":
                    return InstrumentFamilyStr.Bass;
                case "brass":
                    return InstrumentFamilyStr.Brass;
                case "flute":
                    return InstrumentFamilyStr.Flute;
                case "guitar":
                    return InstrumentFamilyStr.Guitar;
                case "keyboard":
                    return InstrumentFamilyStr.Keyboard;
                case "mallet":
                    return InstrumentFamilyStr.Mallet;
                case "organ":
                    return InstrumentFamilyStr.Organ;
                case "reed":
                    return InstrumentFamilyStr.Reed;
                case "string":
                    return InstrumentFamilyStr.String;
                case "vocal":
                    return InstrumentFamilyStr.Vocal;
            }
            throw new Exception("Cannot unmarshal type InstrumentFamilyStr");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InstrumentFamilyStr)untypedValue;
            switch (value)
            {
                case InstrumentFamilyStr.Bass:
                    serializer.Serialize(writer, "bass");
                    return;
                case InstrumentFamilyStr.Brass:
                    serializer.Serialize(writer, "brass");
                    return;
                case InstrumentFamilyStr.Flute:
                    serializer.Serialize(writer, "flute");
                    return;
                case InstrumentFamilyStr.Guitar:
                    serializer.Serialize(writer, "guitar");
                    return;
                case InstrumentFamilyStr.Keyboard:
                    serializer.Serialize(writer, "keyboard");
                    return;
                case InstrumentFamilyStr.Mallet:
                    serializer.Serialize(writer, "mallet");
                    return;
                case InstrumentFamilyStr.Organ:
                    serializer.Serialize(writer, "organ");
                    return;
                case InstrumentFamilyStr.Reed:
                    serializer.Serialize(writer, "reed");
                    return;
                case InstrumentFamilyStr.String:
                    serializer.Serialize(writer, "string");
                    return;
                case InstrumentFamilyStr.Vocal:
                    serializer.Serialize(writer, "vocal");
                    return;
            }
            throw new Exception("Cannot marshal type InstrumentFamilyStr");
        }

        public static readonly InstrumentFamilyStrConverter Singleton = new InstrumentFamilyStrConverter();
    }

    internal class InstrumentSourceStrConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InstrumentSourceStr) || t == typeof(InstrumentSourceStr?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "acoustic":
                    return InstrumentSourceStr.Acoustic;
                case "electronic":
                    return InstrumentSourceStr.Electronic;
                case "synthetic":
                    return InstrumentSourceStr.Synthetic;
            }
            throw new Exception("Cannot unmarshal type InstrumentSourceStr");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InstrumentSourceStr)untypedValue;
            switch (value)
            {
                case InstrumentSourceStr.Acoustic:
                    serializer.Serialize(writer, "acoustic");
                    return;
                case InstrumentSourceStr.Electronic:
                    serializer.Serialize(writer, "electronic");
                    return;
                case InstrumentSourceStr.Synthetic:
                    serializer.Serialize(writer, "synthetic");
                    return;
            }
            throw new Exception("Cannot marshal type InstrumentSourceStr");
        }

        public static readonly InstrumentSourceStrConverter Singleton = new InstrumentSourceStrConverter();
    }

    internal class InstrumentStrConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(InstrumentStr) || t == typeof(InstrumentStr?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bass_electronic_018":
                    return InstrumentStr.BassElectronic018;
                case "bass_electronic_025":
                    return InstrumentStr.BassElectronic025;
                case "bass_electronic_027":
                    return InstrumentStr.BassElectronic027;
                case "bass_synthetic_009":
                    return InstrumentStr.BassSynthetic009;
                case "bass_synthetic_033":
                    return InstrumentStr.BassSynthetic033;
                case "bass_synthetic_034":
                    return InstrumentStr.BassSynthetic034;
                case "bass_synthetic_068":
                    return InstrumentStr.BassSynthetic068;
                case "bass_synthetic_098":
                    return InstrumentStr.BassSynthetic098;
                case "bass_synthetic_134":
                    return InstrumentStr.BassSynthetic134;
                case "bass_synthetic_135":
                    return InstrumentStr.BassSynthetic135;
                case "brass_acoustic_006":
                    return InstrumentStr.BrassAcoustic006;
                case "brass_acoustic_015":
                    return InstrumentStr.BrassAcoustic015;
                case "brass_acoustic_016":
                    return InstrumentStr.BrassAcoustic016;
                case "brass_acoustic_046":
                    return InstrumentStr.BrassAcoustic046;
                case "brass_acoustic_059":
                    return InstrumentStr.BrassAcoustic059;
                case "flute_acoustic_002":
                    return InstrumentStr.FluteAcoustic002;
                case "flute_synthetic_000":
                    return InstrumentStr.FluteSynthetic000;
                case "guitar_acoustic_010":
                    return InstrumentStr.GuitarAcoustic010;
                case "guitar_acoustic_014":
                    return InstrumentStr.GuitarAcoustic014;
                case "guitar_acoustic_015":
                    return InstrumentStr.GuitarAcoustic015;
                case "guitar_acoustic_021":
                    return InstrumentStr.GuitarAcoustic021;
                case "guitar_acoustic_030":
                    return InstrumentStr.GuitarAcoustic030;
                case "guitar_electronic_022":
                    return InstrumentStr.GuitarElectronic022;
                case "guitar_electronic_028":
                    return InstrumentStr.GuitarElectronic028;
                case "keyboard_acoustic_004":
                    return InstrumentStr.KeyboardAcoustic004;
                case "keyboard_electronic_001":
                    return InstrumentStr.KeyboardElectronic001;
                case "keyboard_electronic_002":
                    return InstrumentStr.KeyboardElectronic002;
                case "keyboard_electronic_003":
                    return InstrumentStr.KeyboardElectronic003;
                case "keyboard_electronic_069":
                    return InstrumentStr.KeyboardElectronic069;
                case "keyboard_electronic_078":
                    return InstrumentStr.KeyboardElectronic078;
                case "keyboard_electronic_098":
                    return InstrumentStr.KeyboardElectronic098;
                case "keyboard_synthetic_000":
                    return InstrumentStr.KeyboardSynthetic000;
                case "mallet_acoustic_047":
                    return InstrumentStr.MalletAcoustic047;
                case "mallet_acoustic_056":
                    return InstrumentStr.MalletAcoustic056;
                case "mallet_acoustic_062":
                    return InstrumentStr.MalletAcoustic062;
                case "organ_electronic_001":
                    return InstrumentStr.OrganElectronic001;
                case "organ_electronic_007":
                    return InstrumentStr.OrganElectronic007;
                case "organ_electronic_028":
                    return InstrumentStr.OrganElectronic028;
                case "organ_electronic_057":
                    return InstrumentStr.OrganElectronic057;
                case "organ_electronic_104":
                    return InstrumentStr.OrganElectronic104;
                case "organ_electronic_113":
                    return InstrumentStr.OrganElectronic113;
                case "reed_acoustic_011":
                    return InstrumentStr.ReedAcoustic011;
                case "reed_acoustic_018":
                    return InstrumentStr.ReedAcoustic018;
                case "reed_acoustic_023":
                    return InstrumentStr.ReedAcoustic023;
                case "reed_acoustic_037":
                    return InstrumentStr.ReedAcoustic037;
                case "string_acoustic_012":
                    return InstrumentStr.StringAcoustic012;
                case "string_acoustic_014":
                    return InstrumentStr.StringAcoustic014;
                case "string_acoustic_056":
                    return InstrumentStr.StringAcoustic056;
                case "string_acoustic_057":
                    return InstrumentStr.StringAcoustic057;
                case "string_acoustic_071":
                    return InstrumentStr.StringAcoustic071;
                case "string_acoustic_080":
                    return InstrumentStr.StringAcoustic080;
                case "vocal_acoustic_000":
                    return InstrumentStr.VocalAcoustic000;
                case "vocal_synthetic_003":
                    return InstrumentStr.VocalSynthetic003;
            }
            throw new Exception("Cannot unmarshal type InstrumentStr");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (InstrumentStr)untypedValue;
            switch (value)
            {
                case InstrumentStr.BassElectronic018:
                    serializer.Serialize(writer, "bass_electronic_018");
                    return;
                case InstrumentStr.BassElectronic025:
                    serializer.Serialize(writer, "bass_electronic_025");
                    return;
                case InstrumentStr.BassElectronic027:
                    serializer.Serialize(writer, "bass_electronic_027");
                    return;
                case InstrumentStr.BassSynthetic009:
                    serializer.Serialize(writer, "bass_synthetic_009");
                    return;
                case InstrumentStr.BassSynthetic033:
                    serializer.Serialize(writer, "bass_synthetic_033");
                    return;
                case InstrumentStr.BassSynthetic034:
                    serializer.Serialize(writer, "bass_synthetic_034");
                    return;
                case InstrumentStr.BassSynthetic068:
                    serializer.Serialize(writer, "bass_synthetic_068");
                    return;
                case InstrumentStr.BassSynthetic098:
                    serializer.Serialize(writer, "bass_synthetic_098");
                    return;
                case InstrumentStr.BassSynthetic134:
                    serializer.Serialize(writer, "bass_synthetic_134");
                    return;
                case InstrumentStr.BassSynthetic135:
                    serializer.Serialize(writer, "bass_synthetic_135");
                    return;
                case InstrumentStr.BrassAcoustic006:
                    serializer.Serialize(writer, "brass_acoustic_006");
                    return;
                case InstrumentStr.BrassAcoustic015:
                    serializer.Serialize(writer, "brass_acoustic_015");
                    return;
                case InstrumentStr.BrassAcoustic016:
                    serializer.Serialize(writer, "brass_acoustic_016");
                    return;
                case InstrumentStr.BrassAcoustic046:
                    serializer.Serialize(writer, "brass_acoustic_046");
                    return;
                case InstrumentStr.BrassAcoustic059:
                    serializer.Serialize(writer, "brass_acoustic_059");
                    return;
                case InstrumentStr.FluteAcoustic002:
                    serializer.Serialize(writer, "flute_acoustic_002");
                    return;
                case InstrumentStr.FluteSynthetic000:
                    serializer.Serialize(writer, "flute_synthetic_000");
                    return;
                case InstrumentStr.GuitarAcoustic010:
                    serializer.Serialize(writer, "guitar_acoustic_010");
                    return;
                case InstrumentStr.GuitarAcoustic014:
                    serializer.Serialize(writer, "guitar_acoustic_014");
                    return;
                case InstrumentStr.GuitarAcoustic015:
                    serializer.Serialize(writer, "guitar_acoustic_015");
                    return;
                case InstrumentStr.GuitarAcoustic021:
                    serializer.Serialize(writer, "guitar_acoustic_021");
                    return;
                case InstrumentStr.GuitarAcoustic030:
                    serializer.Serialize(writer, "guitar_acoustic_030");
                    return;
                case InstrumentStr.GuitarElectronic022:
                    serializer.Serialize(writer, "guitar_electronic_022");
                    return;
                case InstrumentStr.GuitarElectronic028:
                    serializer.Serialize(writer, "guitar_electronic_028");
                    return;
                case InstrumentStr.KeyboardAcoustic004:
                    serializer.Serialize(writer, "keyboard_acoustic_004");
                    return;
                case InstrumentStr.KeyboardElectronic001:
                    serializer.Serialize(writer, "keyboard_electronic_001");
                    return;
                case InstrumentStr.KeyboardElectronic002:
                    serializer.Serialize(writer, "keyboard_electronic_002");
                    return;
                case InstrumentStr.KeyboardElectronic003:
                    serializer.Serialize(writer, "keyboard_electronic_003");
                    return;
                case InstrumentStr.KeyboardElectronic069:
                    serializer.Serialize(writer, "keyboard_electronic_069");
                    return;
                case InstrumentStr.KeyboardElectronic078:
                    serializer.Serialize(writer, "keyboard_electronic_078");
                    return;
                case InstrumentStr.KeyboardElectronic098:
                    serializer.Serialize(writer, "keyboard_electronic_098");
                    return;
                case InstrumentStr.KeyboardSynthetic000:
                    serializer.Serialize(writer, "keyboard_synthetic_000");
                    return;
                case InstrumentStr.MalletAcoustic047:
                    serializer.Serialize(writer, "mallet_acoustic_047");
                    return;
                case InstrumentStr.MalletAcoustic056:
                    serializer.Serialize(writer, "mallet_acoustic_056");
                    return;
                case InstrumentStr.MalletAcoustic062:
                    serializer.Serialize(writer, "mallet_acoustic_062");
                    return;
                case InstrumentStr.OrganElectronic001:
                    serializer.Serialize(writer, "organ_electronic_001");
                    return;
                case InstrumentStr.OrganElectronic007:
                    serializer.Serialize(writer, "organ_electronic_007");
                    return;
                case InstrumentStr.OrganElectronic028:
                    serializer.Serialize(writer, "organ_electronic_028");
                    return;
                case InstrumentStr.OrganElectronic057:
                    serializer.Serialize(writer, "organ_electronic_057");
                    return;
                case InstrumentStr.OrganElectronic104:
                    serializer.Serialize(writer, "organ_electronic_104");
                    return;
                case InstrumentStr.OrganElectronic113:
                    serializer.Serialize(writer, "organ_electronic_113");
                    return;
                case InstrumentStr.ReedAcoustic011:
                    serializer.Serialize(writer, "reed_acoustic_011");
                    return;
                case InstrumentStr.ReedAcoustic018:
                    serializer.Serialize(writer, "reed_acoustic_018");
                    return;
                case InstrumentStr.ReedAcoustic023:
                    serializer.Serialize(writer, "reed_acoustic_023");
                    return;
                case InstrumentStr.ReedAcoustic037:
                    serializer.Serialize(writer, "reed_acoustic_037");
                    return;
                case InstrumentStr.StringAcoustic012:
                    serializer.Serialize(writer, "string_acoustic_012");
                    return;
                case InstrumentStr.StringAcoustic014:
                    serializer.Serialize(writer, "string_acoustic_014");
                    return;
                case InstrumentStr.StringAcoustic056:
                    serializer.Serialize(writer, "string_acoustic_056");
                    return;
                case InstrumentStr.StringAcoustic057:
                    serializer.Serialize(writer, "string_acoustic_057");
                    return;
                case InstrumentStr.StringAcoustic071:
                    serializer.Serialize(writer, "string_acoustic_071");
                    return;
                case InstrumentStr.StringAcoustic080:
                    serializer.Serialize(writer, "string_acoustic_080");
                    return;
                case InstrumentStr.VocalAcoustic000:
                    serializer.Serialize(writer, "vocal_acoustic_000");
                    return;
                case InstrumentStr.VocalSynthetic003:
                    serializer.Serialize(writer, "vocal_synthetic_003");
                    return;
            }
            throw new Exception("Cannot marshal type InstrumentStr");
        }

        public static readonly InstrumentStrConverter Singleton = new InstrumentStrConverter();
    }

    internal class QualitiesStrConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(QualitiesStr) || t == typeof(QualitiesStr?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "bright":
                    return QualitiesStr.Bright;
                case "dark":
                    return QualitiesStr.Dark;
                case "distortion":
                    return QualitiesStr.Distortion;
                case "fast_decay":
                    return QualitiesStr.FastDecay;
                case "long_release":
                    return QualitiesStr.LongRelease;
                case "multiphonic":
                    return QualitiesStr.Multiphonic;
                case "nonlinear_env":
                    return QualitiesStr.NonlinearEnv;
                case "percussive":
                    return QualitiesStr.Percussive;
                case "reverb":
                    return QualitiesStr.Reverb;
                case "tempo-synced":
                    return QualitiesStr.TempoSynced;
            }
            throw new Exception("Cannot unmarshal type QualitiesStr");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (QualitiesStr)untypedValue;
            switch (value)
            {
                case QualitiesStr.Bright:
                    serializer.Serialize(writer, "bright");
                    return;
                case QualitiesStr.Dark:
                    serializer.Serialize(writer, "dark");
                    return;
                case QualitiesStr.Distortion:
                    serializer.Serialize(writer, "distortion");
                    return;
                case QualitiesStr.FastDecay:
                    serializer.Serialize(writer, "fast_decay");
                    return;
                case QualitiesStr.LongRelease:
                    serializer.Serialize(writer, "long_release");
                    return;
                case QualitiesStr.Multiphonic:
                    serializer.Serialize(writer, "multiphonic");
                    return;
                case QualitiesStr.NonlinearEnv:
                    serializer.Serialize(writer, "nonlinear_env");
                    return;
                case QualitiesStr.Percussive:
                    serializer.Serialize(writer, "percussive");
                    return;
                case QualitiesStr.Reverb:
                    serializer.Serialize(writer, "reverb");
                    return;
                case QualitiesStr.TempoSynced:
                    serializer.Serialize(writer, "tempo-synced");
                    return;
            }
            throw new Exception("Cannot marshal type QualitiesStr");
        }

        public static readonly QualitiesStrConverter Singleton = new QualitiesStrConverter();
    }
}
