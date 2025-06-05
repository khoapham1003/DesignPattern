


// Iterator Interface
using System.Collections;

abstract class Iterator : IEnumerator
{
    object IEnumerator.Current => Current();

    public abstract object Current();
    public abstract int Key();
    public abstract bool MoveNext();
    public abstract void Reset();
}

// Aggregate Interface
abstract class IteratorAggregate : IEnumerable
{
    public abstract IEnumerator GetEnumerator();
}

// Hồ sơ bệnh án
class PatientRecord
{
    public string PatientName { get; set; }
    public DateTime CreatedDate { get; set; }
    public int PriorityLevel { get; set; } // 1 = Critical, 2 = Urgent, 3 = Normal

    public PatientRecord(string name, DateTime date, int priority)
    {
        PatientName = name;
        CreatedDate = date;
        PriorityLevel = priority;
    }

    public override string ToString()
    {
        return $"{PatientName} | {CreatedDate.ToShortDateString()} | Priority: {PriorityLevel}";
    }
}

// Concrete Iterator
class PatientRecordIterator : Iterator
{
    private List<PatientRecord> _records;
    private int _position = -1;

    public PatientRecordIterator(List<PatientRecord> records)
    {
        _records = records;
    }

    public override object Current() => _records[_position];

    public override int Key() => _position;

    public override bool MoveNext()
    {
        _position++;
        return _position < _records.Count;
    }

    public override void Reset()
    {
        _position = 0;
    }
}

// Concrete Collection
class PatientRecordCollection : IteratorAggregate
{
    private List<PatientRecord> _records = new List<PatientRecord>();

    public enum TraversalMode
    {
        ByDate,
        ByDateReverse,
        ByPriority
    }

    private TraversalMode _mode = TraversalMode.ByDate;

    public void AddRecord(PatientRecord record) => _records.Add(record);

    public void SetTraversalMode(TraversalMode mode) => _mode = mode;

    public override IEnumerator GetEnumerator()
    {
        List<PatientRecord> sorted;

        switch (_mode)
        {
            case TraversalMode.ByDateReverse:
                sorted = _records.OrderByDescending(r => r.CreatedDate).ToList();
                break;
            case TraversalMode.ByPriority:
                sorted = _records.OrderBy(r => r.PriorityLevel).ToList(); 
                break;
            default:
                sorted = _records.OrderBy(r => r.CreatedDate).ToList();
                break;
        }

        return new PatientRecordIterator(sorted);
    }
}
