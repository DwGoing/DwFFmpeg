using System.Text.Json.Serialization;

namespace DwFFmpeg
{
    public class PacketInfo
    {
        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; }
        [JsonPropertyName("stream_index")]
        public long StreamIndex { get; set; }
        [JsonPropertyName("pts")]
        public long Pts { get; set; }
        [JsonPropertyName("pts_time")]
        public string PtsTime { get; set; }
        [JsonPropertyName("dts")]
        public long Dts { get; set; }
        [JsonPropertyName("dts_time")]
        public string DtsTime { get; set; }
        [JsonPropertyName("duration")]
        public long Duration { get; set; }
        [JsonPropertyName("duration_time")]
        public string DurationTime { get; set; }
        [JsonPropertyName("size")]
        public string Size { get; set; }
        [JsonPropertyName("pos")]
        public string Pos { get; set; }
        [JsonPropertyName("flags")]
        public string Flags { get; set; }
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }

    public class FormatInfo
    {
        public class Tag
        {
            [JsonPropertyName("major_brand")]
            public string MajorBrand { get; set; }
            [JsonPropertyName("minor_version")]
            public string MinorVersion { get; set; }
            [JsonPropertyName("compatible_brands")]
            public string CompatibleBrands { get; set; }
            [JsonPropertyName("encoder")]
            public string Encoder { get; set; }
        }

        [JsonPropertyName("filename")]
        public string FileName { get; set; }
        [JsonPropertyName("nb_streams")]
        public int NbStreams { get; set; }
        [JsonPropertyName("nb_programs")]
        public int NbPrograms { get; set; }
        [JsonPropertyName("format_name")]
        public string FormatName { get; set; }
        [JsonPropertyName("format_long_name")]
        public string FormatLongName { get; set; }
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("size")]
        public string Size { get; set; }
        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; }
        [JsonPropertyName("probe_score")]
        public int ProbeScore { get; set; }
        [JsonPropertyName("tags")]
        public Tag Tags { get; set; }
    }

    public class FrameInfo
    {
        [JsonPropertyName("media_type")]
        public string MediaType { get; set; }
        [JsonPropertyName("key_frame")]
        public int KeyFrame { get; set; }
        [JsonPropertyName("pkt_pts")]
        public long PktPts { get; set; }
        [JsonPropertyName("pkt_pts_time")]
        public string PktPtsTime { get; set; }
        [JsonPropertyName("pkt_dts")]
        public long PktDts { get; set; }
        [JsonPropertyName("pkt_dts_time")]
        public string PktDtsTime { get; set; }
        [JsonPropertyName("best_effort_timestamp")]
        public long BestEffortTimestamp { get; set; }
        [JsonPropertyName("best_effort_timestamp_time")]
        public string BestEffortTimestampTime { get; set; }
        [JsonPropertyName("pkt_duration")]
        public long PktDuration { get; set; }
        [JsonPropertyName("pkt_duration_time")]
        public string PktDurationTime { get; set; }
        [JsonPropertyName("pkt_pos")]
        public string PktPos { get; set; }
        [JsonPropertyName("pkt_size")]
        public string PktSize { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("pix_fmt")]
        public string PixFmt { get; set; }
        [JsonPropertyName("pict_type")]
        public string PictType { get; set; }
        [JsonPropertyName("coded_picture_number")]
        public int CodedPictureNumber { get; set; }
        [JsonPropertyName("display_picture_number")]
        public int DisplayPictureNumber { get; set; }
        [JsonPropertyName("interlaced_frame")]
        public long InterlacedFrame { get; set; }
        [JsonPropertyName("top_field_first")]
        public long TopFieldFirst { get; set; }
        [JsonPropertyName("repeat_pict")]
        public long RepeatPict { get; set; }
        [JsonPropertyName("color_range")]
        public string ColorRange { get; set; }
        [JsonPropertyName("chroma_location")]
        public string ChromaLocation { get; set; }
    }

    public class StreamInfo
    {
        public class Disposition
        {
            [JsonPropertyName("default")]
            public int Default { get; set; }
            [JsonPropertyName("dub")]
            public int Dub { get; set; }
            [JsonPropertyName("original")]
            public int Original { get; set; }
            [JsonPropertyName("comment")]
            public int Comment { get; set; }
            [JsonPropertyName("lyrics")]
            public int Lyrics { get; set; }
            [JsonPropertyName("karaoke")]
            public int Karaoke { get; set; }
            [JsonPropertyName("forced")]
            public int Forced { get; set; }
            [JsonPropertyName("hearing_impaired")]
            public int HearingImpaired { get; set; }
            [JsonPropertyName("visual_impaired")]
            public int VisualImpaired { get; set; }
            [JsonPropertyName("clean_effects")]
            public int CleanEffects { get; set; }
            [JsonPropertyName("attached_pic")]
            public int AttachedPic { get; set; }
            [JsonPropertyName("timed_thumbnails")]
            public int TimedThumbnails { get; set; }
        }

        public class Tag
        {
            [JsonPropertyName("language")]
            public string Language { get; set; }
            [JsonPropertyName("handler_name")]
            public string HandlerName { get; set; }
        }

        [JsonPropertyName("index")]
        public long Index { get; set; }
        [JsonPropertyName("codec_name")]
        public string CodecName { get; set; }
        [JsonPropertyName("codec_long_name")]
        public string CodecLongName { get; set; }
        [JsonPropertyName("profile")]
        public string Profile { get; set; }
        [JsonPropertyName("codec_type")]
        public string CodecType { get; set; }
        [JsonPropertyName("codec_time_base")]
        public string CodecTimeBase { get; set; }
        [JsonPropertyName("codec_tag_string")]
        public string CodecTagString { get; set; }
        [JsonPropertyName("codec_tag")]
        public string CodecTag { get; set; }
        [JsonPropertyName("width")]
        public int Width { get; set; }
        [JsonPropertyName("height")]
        public int Height { get; set; }
        [JsonPropertyName("coded_width")]
        public int CodedWidth { get; set; }
        [JsonPropertyName("coded_height")]
        public int CodedHeight { get; set; }
        [JsonPropertyName("closed_captions")]
        public int ClosedCaptionsCodedHeight { get; set; }
        [JsonPropertyName("has_b_frame")]
        public int HasBFrame { get; set; }
        [JsonPropertyName("pix_fmt")]
        public string PixFmt { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("color_range")]
        public string ColorRange { get; set; }
        [JsonPropertyName("chroma_location")]
        public string ChromaLocation { get; set; }
        [JsonPropertyName("refs")]
        public int Refs { get; set; }
        [JsonPropertyName("is_avc")]
        public string IsAvc { get; set; }
        [JsonPropertyName("nal_length_size")]
        public string NalLengthSize { get; set; }
        [JsonPropertyName("r_frame_rate")]
        public string RFrameRate { get; set; }
        [JsonPropertyName("avg_frame_rate")]
        public string AvgFrameRate { get; set; }
        [JsonPropertyName("time_base")]
        public string TimeBase { get; set; }
        [JsonPropertyName("start_pts")]
        public long StarPts { get; set; }
        [JsonPropertyName("start_time")]
        public string StartTime { get; set; }
        [JsonPropertyName("duration_ts")]
        public long DurationTs { get; set; }
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("bit_rate")]
        public string BitRate { get; set; }
        [JsonPropertyName("bits_per_raw_sample")]
        public string BitsPerRawSample { get; set; }
        [JsonPropertyName("nb_frames")]
        public string NbFrames { get; set; }
        [JsonPropertyName("disposition")]
        public Disposition Dispositions { get; set; }
        [JsonPropertyName("tags")]
        public Tag Tags { get; set; }
    }
}
