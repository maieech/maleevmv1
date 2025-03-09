using System.ComponentModel;
using System;

public class Request : INotifyPropertyChanged
{
    private string _requestNumber;
    private DateTime _requestDate;
    private string _equipmentType;
    private string _model;
    private string _problemDescription;
    private string _clientName;
    private string _phoneNumber;
    private string _status;
    private string _responsiblePerson;
    private string _masterComment; // Комментарий мастера

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public string RequestNumber
    {
        get => _requestNumber;
        set
        {
            _requestNumber = value;
            OnPropertyChanged(nameof(RequestNumber));
        }
    }

    public DateTime RequestDate
    {
        get => _requestDate;
        set
        {
            _requestDate = value;
            OnPropertyChanged(nameof(RequestDate));
        }
    }

    public string EquipmentType
    {
        get => _equipmentType;
        set
        {
            _equipmentType = value;
            OnPropertyChanged(nameof(EquipmentType));
        }
    }

    public string Model
    {
        get => _model;
        set
        {
            _model = value;
            OnPropertyChanged(nameof(Model));
        }
    }

    public string ProblemDescription
    {
        get => _problemDescription;
        set
        {
            _problemDescription = value;
            OnPropertyChanged(nameof(ProblemDescription));
        }
    }

    public string ClientName
    {
        get => _clientName;
        set
        {
            _clientName = value;
            OnPropertyChanged(nameof(ClientName));
        }
    }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            _phoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            _status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    public string ResponsiblePerson
    {
        get => _responsiblePerson;
        set
        {
            _responsiblePerson = value;
            OnPropertyChanged(nameof(ResponsiblePerson));
        }
    }

    public string MasterComment
    {
        get => _masterComment;
        set
        {
            _masterComment = value;
            OnPropertyChanged(nameof(MasterComment));
        }
    }
}
