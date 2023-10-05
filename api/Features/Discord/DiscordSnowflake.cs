namespace api.Features.Discord;

public class DiscordSnowflake
{
    public long TimeStamp { get; private set; }
    public long WorkerId { get; }
    public long DatacenterId { get; }
    public long Sequence { get; private set; }

    private const long DiscordEpoch = 1420070400000;
    private const int WorkerIdBits = 5;
    private const int DatacenterIdBits = 5;
    private const int SequenceBits = 12;

    private const long MaxWorkerId = -1L ^ (-1L << WorkerIdBits);
    private const long MaxDatacenterId = -1L ^ (-1L << DatacenterIdBits);

    private const long MaxSequence = -1L ^ (-1L << SequenceBits);

    private const int WorkerIdShift = SequenceBits;
    private const int DatacenterIdShift = SequenceBits + WorkerIdBits;
    private const int TimestampLeftShift = SequenceBits + WorkerIdBits + DatacenterIdBits;

    // Decode a snowflake into its constituent parts from a string
    public static (long timestamp, long workerId, long datacenterId, long sequence) Decode(string snowflakeString)
    {
        var snowflake = long.Parse(snowflakeString);
        var binary = Convert.ToString(snowflake, 2).PadLeft(64, '0');

        var timestamp = Convert.ToInt64(binary[..42], 2);
        var workerId = Convert.ToInt64(binary[42..47], 2);
        var datacenterId = Convert.ToInt64(binary[47..52], 2);
        var sequence = Convert.ToInt64(binary[52..], 2);

        return (timestamp, workerId, datacenterId, sequence);
    }

    // Encode a snowflake into a string
    public static string Encode(long snowflake)
    {
        var binary = Convert.ToString(snowflake, 2).PadLeft(64, '0');

        var timestamp = Convert.ToInt64(binary[..42], 2);
        var workerId = Convert.ToInt64(binary[42..47], 2);
        var datacenterId = Convert.ToInt64(binary[47..52], 2);
        var sequence = Convert.ToInt64(binary[52..], 2);

        return $"{timestamp}{workerId}{datacenterId}{sequence}";
    }

    public DiscordSnowflake()
    {
        var timestamp = TimeGen();
        var workerId = 0L;
        var datacenterId = 0L;
        var sequence = 0L;

        TimeStamp = timestamp;
        WorkerId = workerId;
        DatacenterId = datacenterId;
        Sequence = sequence;
    }

    public DiscordSnowflake(string snowflakeString)
    {
        var snowflake = long.Parse(snowflakeString);
        var binary = Convert.ToString(snowflake, 2).PadLeft(64, '0');

        var timestamp = Convert.ToInt64(binary[..42], 2);
        var workerId = Convert.ToInt64(binary[42..47], 2);
        var datacenterId = Convert.ToInt64(binary[47..52], 2);
        var sequence = Convert.ToInt64(binary[52..], 2);

        TimeStamp = timestamp;
        WorkerId = workerId;
        DatacenterId = datacenterId;
        Sequence = sequence;
    }

    public DiscordSnowflake(long workerId, long datacenterId, long sequence = 0)
    {
        if (workerId > MaxWorkerId || workerId < 0)
        {
            throw new ArgumentException($"worker Id can't be greater than {MaxWorkerId} or less than 0");
        }

        if (datacenterId > MaxDatacenterId || datacenterId < 0)
        {
            throw new ArgumentException($"datacenter Id can't be greater than {MaxDatacenterId} or less than 0");
        }

        WorkerId = workerId;
        DatacenterId = datacenterId;
        Sequence = sequence;
    }

    // Generate a new snowflake
    public long Next()
    {
        var timestamp = TimeGen();

        if (Sequence == MaxSequence)
        {
            timestamp = TilNextMillis();
            Sequence = 0;
        }
        else
        {
            Sequence++;
        }

        return ((timestamp - DiscordEpoch) << TimestampLeftShift) |
               (DatacenterId << DatacenterIdShift) |
               (WorkerId << WorkerIdShift) |
               Sequence;
    }

    private static long TilNextMillis()
    {
        var timestamp = TimeGen();
        while (timestamp <= TimeGen())
        {
            timestamp = TimeGen();
        }
        return timestamp;
    }

    private static long TimeGen()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }

    // convert discord snowflake to datetimeoffset
    public static DateTimeOffset ToDateTimeOffset(long timestamp)
    {
        return DateTimeOffset.FromUnixTimeMilliseconds(timestamp + DiscordEpoch);
    }
}
