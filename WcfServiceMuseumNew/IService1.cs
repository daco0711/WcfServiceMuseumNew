using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceMuseumNew
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract(Action = "MuseumService/GetMuseum")]
        List<Museum> getMuseum();
        
        [OperationContract(Action = "MuseumService/UpdateMuseum")]
        void updateMuseum(Int32 museumId, String museumName, String museumAddress, DateTime established);

        [OperationContract(Action = "MuseumService/GetLocations")]
        List<Locations> getLocations();

        [OperationContract(Action = "MuseumService/UpdateLocations")]
        void updateLocations(Int32 locationId, String locationName, String surface, String state, String leasePrice, Int32 museumIdFK, String country);

        [OperationContract(Action = "MuseumService/DeleteLocation")]
        void deleteLocation(Int32 locationId);

        [OperationContract(Action = "MuseumService/FindLocations")]
        List<Locations> findLocations(String locationName);

        [OperationContract(Action = "MuseumService/AddLocations")]
        void addLocations(String locationName, String surface, String state, String leasePrice, Int32 museumIdFK, String country);

        [OperationContract(Action = "MuseumService/GetExhibits")]
        List<Exhibits> getExhibits();

        [OperationContract(Action = "MuseumService/FindExhibits")]
        List<Exhibits> findExhibits(String type, String historicPeriod);

        [OperationContract(Action = "MuseumService/DeleteExhibits")]
        void deleteExhibits(Int32 exhibitId);


        [OperationContract(Action = "MuseumService/AddExhibits")]
        void addExhibits(String type, String dimensions, String historicPeriod, Int32 locationIdFK, Int32 orderFormIdFK);

        [OperationContract(Action = "MuseumService/UpdateExhibits")]
        void updateExhibits(Int32 exhibitId, String type, String dimensions, String historicPeriod, Int32 locationIdFK, Int32 orderFormIdFK);

        [OperationContract(Action = "MuseumService/GetOrderForms")]
        List<OrderForms> getOrderForms();

        [OperationContract(Action = "ServiceMuseum/DeleteOrderForms")]
        void deleteOrderForms(Int32 orderFormId);

        [OperationContract(Action = "MuseumService/AddOrderForms")]
        void addOrderForms( DateTime date, String buyerAdress, Int32 buyerIdFk);

        [OperationContract(Action = "MuseumService/UpdateOrderForms")]
        void updateOrderForms(Int32 orderFormId, DateTime date, String buyerAddress, Int32 buyerIdFk);

        [OperationContract(Action = "MuseumService/FindOrderForms")]
        List<OrderForms> findOrderForms(Int32 buyerIdFk, String buyerAdress);

        [OperationContract(Action = "MuseumService/GetBuyers")]
        List<Buyers> getBuyers();

        [OperationContract(Action = "MuseumService/DeleteBuyers")]
        void deleteBuyers(Int32 buyerId);

        [OperationContract(Action = "MuseumService/AddBuyers")]
        void addBuyers(String buyersName, String buyersSurname, String buyersAddress, String buyersCountry);

        [OperationContract(Action = "MuseumService/UpdateBuyers")]
        void updateBuyers(Int32 buyersId, String buyersName, String buyersSurname, String buyersAddress, String buyersCountry);

        [OperationContract(Action = "MuseumService/FindBuyers")]
        List<Buyers> findBuyers(String buyersName, String buyersSurname);

        [OperationContract(Action = "MuseumService/GetUsers")]
        List<Users> getUsers();

        [OperationContract(Action = "MuseumService/DeleteUsers")]
        void deleteUsers(Int32 userId);

        [OperationContract(Action = "MuseumService/FindUsers")]
        List<Users> findUsers(String name,String userName);

        



        


        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Museum
    {
        public Int32 museumId;
        public String museumName;
        public String museumAddress;
        public DateTime established;

        [DataMember]
        public Int32 MuseumId
        {
            get{return museumId;}
            set { museumId = value; }

        }
        [DataMember]
        public String MuseumName
        {
            get { return museumName; }
            set { museumName = value; }
        }
        [DataMember]
        public String MuseumAddress
        {
            get { return museumAddress; }
            set { museumAddress = value; }
        }
        [DataMember]
        public DateTime Established
        {
            get{return established;}
            set { established = value; }
        }

        
    }

    [DataContract]
    public class Exhibits
    {

        public Int32 exhibitId;
        public String type;
        public String dimensions;
        public String historicPeriod;
        public Int32 locationIdFK;
        public Int32 orderFormIdFK;

        [DataMember]
        public Int32 ExhibitId
        {
            get { return exhibitId; }
            set { exhibitId = value; }
        }
        [DataMember]
        public String Type
        {
            get { return type; }
            set { type = value; }
        }
        [DataMember]
        public String Dimensions
    {
        get { return dimensions; }
        set { dimensions = value; }
    }
        [DataMember]
        public String HistoricPeriod
        {
            get { return historicPeriod; }
            set { historicPeriod = value; }
        }
        [DataMember]
        public Int32 LocationIdFK
        {
            get{return locationIdFK;}
            set {locationIdFK = value;}
        }
        [DataMember]
        public Int32 OrderFormIdFK
        {
            get{return orderFormIdFK;}
            set{orderFormIdFK = value;}
        }
    }

    [DataContract]
    public class Locations
    {
        public Int32 locationId;
        public String locationName;
        public String surface;
        public String state;
        public String leasePrice;
        public Int32 museumIdFK;
        public String country;

        [DataMember]
        public Int32 LocationId
        {
            get{return locationId;}
            set { locationId = value; }
        }
        [DataMember]
        public String LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
        [DataMember]
        public String Surface
        {
            get { return surface; }
            set { surface = value; }
        }
        [DataMember]
        public String State
        {
            get { return state; }
            set { state = value; }
        }
        [DataMember]
        public String LeasePrice
        {
            get { return leasePrice; }
            set { leasePrice = value; }
        }
        [DataMember]
        public Int32 MuseumIdFK
        {
            get { return museumIdFK; }
            set { museumIdFK = value; }
        }
        [DataMember]
        public String Country
        {
            get { return country; }
            set { country = value; }
        }
    }

    [DataContract]
    public class OrderForms
    {
        public Int32 orderFormId;
        public DateTime date;
        public String buyerAddress;
        public Int32 buyerIdFK;

        [DataMember]
        public Int32 OrderFormId
        {
            get { return orderFormId; }
            set { orderFormId = value; }
        }

        [DataMember]
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public String BuyerAddress
        {

            get { return buyerAddress; }
            set { buyerAddress = value; }
        }

        [DataMember]
        public Int32 BuyerIdFK
        {
            get { return buyerIdFK; }
            set { buyerIdFK = value; }
        }

    }
    [DataContract]
    public class Buyers
    {
        Int32 buyerId;
        String buyersName;
        String buyersSurname;
        String buyersAddress;
        String buyersCountry;

        [DataMember]
        public Int32 BuyersId
        {
            get { return buyerId; }
            set { buyerId = value; }
        }
        [DataMember]
        public String BuyersName
        {
            get { return buyersName; }
            set { buyersName = value; }
        }
        [DataMember]
        public String BuyersSurname
        {
            get { return buyersSurname; }
            set { buyersSurname = value; }
        }
        [DataMember]
        public String BuyersAddress
        {
            get { return buyersAddress; }
            set { buyersAddress = value; }
        }
        [DataMember]
        public String BuyersCountry
        {
            get { return buyersCountry; }
            set { buyersCountry = value; }
        }

    
    }

    [DataContract]
    public class Users
    {

        Int32 userId;
        String name;
        String userName;
        String password;
        Boolean isAdministrator;

        [DataMember]
        public Int32 UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        [DataMember]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        [DataMember]
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public Boolean IsAdministrator
        {
            get { return isAdministrator; }
            set { isAdministrator = value; }
        }
    }
    
    
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
