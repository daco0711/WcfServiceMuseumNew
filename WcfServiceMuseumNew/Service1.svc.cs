using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WcfServiceMuseumNew
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<Museum> getMuseum()
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblMuseum");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Museum> museums = new List<Museum>();

            while (reader.Read())
            {
                Museum museum = new Museum();
                if (!Convert.IsDBNull(reader["MuseumId"]))
                {
                    museum.MuseumId = Convert.ToInt32(reader["MuseumId"]);
                }
                if (!Convert.IsDBNull(reader["MuseumId"]))
                {
                    museum.MuseumName = Convert.ToString(reader["MuseumName"]);
                }
                if (!Convert.IsDBNull(reader["MuseumId"]))
                {
                    museum.MuseumAddress = Convert.ToString(reader["MuseumAddress"]);
                }
                if (!Convert.IsDBNull(reader["MuseumId"]))
                {
                    museum.Established = Convert.ToDateTime(reader["Established"]);
                }
                museums.Add(museum);
            }
            return museums;
        }
        public List<Users> getUsers()
        {

            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblUsers");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Users> users = new List<Users>();

            while (reader.Read())
            {
                Users user = new Users();
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.Name = Convert.ToString(reader["Name"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.UserName = Convert.ToString(reader["UserName"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.Password = Convert.ToString(reader["Password"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.IsAdministrator = Convert.ToBoolean(reader["IsAdministrator"]);
                }

                users.Add(user);
            }
            return users;

        }




        public List<OrderForms> getOrderForms()
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblOrderForms");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<OrderForms> orderforms = new List<OrderForms>();

            while (reader.Read())
            {
                OrderForms orderForm = new OrderForms();
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    orderForm.orderFormId = Convert.ToInt32(reader["OrderFormId"]);
                }
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    orderForm.date = Convert.ToDateTime(reader["date"]);
                }
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    orderForm.buyerAddress = Convert.ToString(reader["BuyerAdress"]);
                }
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    orderForm.buyerIdFK = Convert.ToInt32(reader["BuyerIdFk"]);
                }
                orderforms.Add(orderForm);
            }
            return orderforms;



        }

        public void updateMuseum(Int32 museumId, String museumName, String museumAddress, DateTime established)
        {
            SqlConnection conection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String qString = ("update tblMuseum set museumName=@museumName,museumAddress=@museumAddress,established=@established where MuseumId=@museumId");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@museumId", SqlDbType.Int);
            cmd.Parameters["@museumId"].Value = museumId;

            cmd.Parameters.Add("@museumName", SqlDbType.VarChar);
            cmd.Parameters["@museumName"].Value = museumName;

            cmd.Parameters.Add("@museumAddress", SqlDbType.VarChar);
            cmd.Parameters["@museumAddress"].Value = museumAddress;

            cmd.Parameters.Add("@established", SqlDbType.DateTime);
            cmd.Parameters["@established"].Value = established;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void updateUsers(Int32 userID, String name, String userName, String password, Boolean isAdministrator)
        {
            SqlConnection conection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String qString = ("update tblUsers set name=@name,userName=@userName,password=@password,isAdministrator=@isAdministrator where UserId=@userId");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@userId", SqlDbType.Int);
            cmd.Parameters["@userId"].Value = userID;

            cmd.Parameters.Add("@name", SqlDbType.VarChar);
            cmd.Parameters["@name"].Value = name;

            cmd.Parameters.Add("@userName", SqlDbType.VarChar);
            cmd.Parameters["@userName"].Value = userName;

            cmd.Parameters.Add("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = password;


            cmd.Parameters.Add("@isAdministrator", SqlDbType.Bit);
            cmd.Parameters["@isAdministrator"].Value = isAdministrator;
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }

        }



        public void updateBuyers(Int32 buyersId, String buyersName, String buyersSurname, String buyersAddress, String buyersCountry)
        {

            SqlConnection conection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String qString = ("update tblBuyers set buyersName=@buyersName,buyersSurname=@buyersSurname,buyersAddress=@buyersAddress,buyersCountry=@buyersCountry where BuyerId=@buyerId");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@buyerId", SqlDbType.Int);
            cmd.Parameters["@buyerId"].Value = buyersId;

            cmd.Parameters.Add("@buyersName", SqlDbType.VarChar);
            cmd.Parameters["@buyersName"].Value = buyersName;

            cmd.Parameters.Add("@buyersSurname", SqlDbType.VarChar);
            cmd.Parameters["@buyersSurname"].Value = buyersSurname;

            cmd.Parameters.Add("@buyersAddress", SqlDbType.VarChar);
            cmd.Parameters["@buyersAddress"].Value = buyersAddress;

            cmd.Parameters.Add("@buyersCountry", SqlDbType.VarChar);
            cmd.Parameters["@buyersCountry"].Value = buyersCountry;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }



        public void updateOrderForms(Int32 orderFormId, DateTime date, String buyerAddress, Int32 buyerIdFk)
        {
            SqlConnection conection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String qString = ("update tblOrderForms set date=@date,buyerAdress=@buyerAdress,buyerIdFk=@buyerIdFk where OrderFormId=@orderFormId");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@orderFormId", SqlDbType.Int);
            cmd.Parameters["@orderFormId"].Value = orderFormId;

            cmd.Parameters.Add("@date", SqlDbType.DateTime);
            cmd.Parameters["@date"].Value = date;

            cmd.Parameters.Add("@buyerAdress", SqlDbType.VarChar);
            cmd.Parameters["@buyerAdress"].Value = buyerAddress;

            cmd.Parameters.Add("@buyerIdFk", SqlDbType.Int);
            cmd.Parameters["@buyerIdFk"].Value = buyerIdFk;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }


        }





        public List<Locations> getLocations()
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblLocations");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Locations> locations = new List<Locations>();

            while (reader.Read())
            {
                Locations location = new Locations();
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LocationId = Convert.ToInt32(reader["LocationId"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LocationName = Convert.ToString(reader["LocationName"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.Surface = Convert.ToString(reader["Surface"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.State = Convert.ToString(reader["State"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LeasePrice = Convert.ToString(reader["LeasePrice"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.MuseumIdFK = Convert.ToInt32(reader["MuseumIdFK"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.Country = Convert.ToString(reader["Country"]);
                }
                locations.Add(location);
            }
            return locations;
        }


        public void updateLocations(Int32 locationId, String locationName, String surface, String state, String leasePrice, Int32 museumIdFK, String country)
        {
            SqlConnection conection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String qString = ("update tblLocations set locationName=@locationName,surface=@surface,state=@state,leasePrice=@leasePrice,museumIdFK=@museumIdFk,country=@country where LocationId=@locationId");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@locationId", SqlDbType.Int);
            cmd.Parameters["@locationId"].Value = locationId;

            cmd.Parameters.Add("@locationName", SqlDbType.VarChar);
            cmd.Parameters["@locationName"].Value = locationName;

            cmd.Parameters.Add("@surface", SqlDbType.VarChar);
            cmd.Parameters["@surface"].Value = surface;

            cmd.Parameters.Add("@state", SqlDbType.VarChar);
            cmd.Parameters["@state"].Value = state;

            cmd.Parameters.Add("@leasePrice", SqlDbType.VarChar);
            cmd.Parameters["@leasePrice"].Value = leasePrice;

            cmd.Parameters.Add("@museumIdFK", SqlDbType.Int);
            cmd.Parameters["@museumIdFK"].Value = museumIdFK;

            cmd.Parameters.Add("@country", SqlDbType.VarChar);
            cmd.Parameters["@country"].Value = country;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void updateExhibits(Int32 exhibitId, String type, String dimensions, String historicPeriod, Int32 locationIdFK, Int32 orderFormIdFK)
        {
            Exhibits exhibit = new Exhibits();
            SqlConnection conection = new SqlConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            String qString = ("update tblExhibits set type=@type,dimensions=@dimensions,historicPeriod=@historicPeriod,locationIdFK=@locationIdFK,orderFormIdFK=@orderFormIdFK where exhibitId=@exhibitId");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@exhibitId", SqlDbType.Int);
            cmd.Parameters["@exhibitId"].Value = exhibitId;

            cmd.Parameters.Add("@type", SqlDbType.VarChar);
            cmd.Parameters["@type"].Value = type;

            cmd.Parameters.Add("@dimensions", SqlDbType.VarChar);
            cmd.Parameters["@dimensions"].Value = dimensions;

            cmd.Parameters.Add("@historicPeriod", SqlDbType.VarChar);
            cmd.Parameters["@historicPeriod"].Value = historicPeriod;

            cmd.Parameters.Add("@locationIdFK", SqlDbType.Int);
            cmd.Parameters["@locationIdFK"].Value = locationIdFK;

            cmd.Parameters.Add("@orderFormIdFK", SqlDbType.Int);
            cmd.Parameters["@orderFormIdFK"].Value = orderFormIdFK;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }




        public void deleteLocation(Int32 locationId)
        {
            Locations delLoc = new Locations();
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("delete from tblLocations where LocationId= '" + locationId + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Close();
        }

        public void deleteOrderForms(Int32 orderFormId)
        {
            OrderForms delOrdF = new OrderForms();
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("delete from tblOrderForms where OrderFormId= '" + orderFormId + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Close();
        }
        public void deleteBuyers(Int32 buyerId)
        {
            Buyers delBuyers = new Buyers();
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("delete from tblBuyers where BuyerId= '" + buyerId + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Close();

        }

        public List<Locations> findLocations(String locationName)
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblLocations where LocationName ='" + locationName + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Locations> locations = new List<Locations>();

            while (reader.Read())
            {
                Locations location = new Locations();
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LocationId = Convert.ToInt32(reader["LocationId"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LocationName = Convert.ToString(reader["LocationName"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.Surface = Convert.ToString(reader["Surface"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.State = Convert.ToString(reader["State"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LeasePrice = Convert.ToString(reader["LeasePrice"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.MuseumIdFK = Convert.ToInt32(reader["MuseumIdFK"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.Country = Convert.ToString(reader["Country"]);
                }
                locations.Add(location);
            }
            return locations;
        }

        public Locations getLocationsByID(Int32 locationID)
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblLocations where LocationId = " + locationID);
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();

            if (reader.Read())
            {
                Locations location = new Locations();

                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LocationId = Convert.ToInt32(reader["LocationId"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LocationName = Convert.ToString(reader["LocationName"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.Surface = Convert.ToString(reader["Surface"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.State = Convert.ToString(reader["State"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.LeasePrice = Convert.ToString(reader["LeasePrice"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.MuseumIdFK = Convert.ToInt32(reader["MuseumIdFK"]);
                }
                if (!Convert.IsDBNull(reader["LocationId"]))
                {
                    location.Country = Convert.ToString(reader["Country"]);
                }

                return location;
            }
            else
            {
                return null;
            }
        }

        public List<OrderForms> findOrderForms(Int32 buyerIdFk, String buyerAdress)
        {

            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblOrderForms where BuyerIdFk = '" + buyerIdFk + "' or BuyerAdress='" + buyerAdress + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<OrderForms> orderForms = new List<OrderForms>();

            while (reader.Read())
            {
                OrderForms order = new OrderForms();
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    order.OrderFormId = Convert.ToInt32(reader["OrderFormId"]);
                }
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    order.Date = Convert.ToDateTime(reader["Date"]);
                }
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    order.BuyerAddress = Convert.ToString(reader["BuyerAdress"]);
                }
                if (!Convert.IsDBNull(reader["OrderFormId"]))
                {
                    order.BuyerIdFK = Convert.ToInt32(reader["BuyerIdFk"]);
                }


                orderForms.Add(order);
            }
            return orderForms;
        }




        public void addLocations(String locationName, String surface, String state, String leasePrice, Int32 museumIdFK, String country)
        {
            Locations addLoc = new Locations();
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            string qString = "insert into tblLocations (LocationName,Surface,State,LeasePrice,MuseumIdFK,Country) values (@LocationName,@Surface,@State,@LeasePrice,@MuseumIdFK,@Country)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@LocationName", SqlDbType.VarChar);
            cmd.Parameters["@LocationName"].Value = locationName;

            cmd.Parameters.Add("@Surface", SqlDbType.VarChar);
            cmd.Parameters["@Surface"].Value = surface;

            cmd.Parameters.Add("@State", SqlDbType.VarChar);
            cmd.Parameters["@State"].Value = state;

            cmd.Parameters.Add("@LeasePrice", SqlDbType.VarChar);
            cmd.Parameters["@LeasePrice"].Value = leasePrice;

            cmd.Parameters.Add("@MuseumIdFK", SqlDbType.Int);
            cmd.Parameters["@MuseumIdFK"].Value = museumIdFK;

            cmd.Parameters.Add("@Country", SqlDbType.VarChar);
            cmd.Parameters["@Country"].Value = country;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }

        }

        public void addBuyers(String buyersName, String buyersSurname, String buyersAddress, String buyersCountry)
        {

            Buyers buyers = new Buyers();
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            string qString = "insert into tblBuyers (BuyersName,BuyersSurname,BuyersAddress,BuyersCountry) values (@BuyersName,@BuyersSurname,@BuyersAddress,@BuyersCountry)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@BuyersName", SqlDbType.VarChar);
            cmd.Parameters["@BuyersName"].Value = buyersName;

            cmd.Parameters.Add("@BuyersSurname", SqlDbType.VarChar);
            cmd.Parameters["@BuyersSurname"].Value = buyersSurname;

            cmd.Parameters.Add("@BuyersAddress", SqlDbType.VarChar);
            cmd.Parameters["@BuyersAddress"].Value = buyersAddress;

            cmd.Parameters.Add("@BuyersCountry", SqlDbType.VarChar);
            cmd.Parameters["@BuyersCountry"].Value = buyersCountry;



            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }

        }


        public void addExhibits(String type, String dimensions, String historicPeriod, Int32 locationIdFK, Int32 orderFormIdFK)
        {
            Exhibits exh = new Exhibits();
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            string qString = "insert into tblExhibits (Type,Dimensions,HistoricPeriod,LocationIdFK,OrderFormIdFK) values (@Type,@Dimensions,@HistoricPeriod,@LocationIdFK,@OrderFormIdFK)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@Type", SqlDbType.VarChar);
            cmd.Parameters["@Type"].Value = type;

            cmd.Parameters.Add("@Dimensions", SqlDbType.VarChar);
            cmd.Parameters["@Dimensions"].Value = dimensions;

            cmd.Parameters.Add("@HistoricPeriod", SqlDbType.VarChar);
            cmd.Parameters["@HistoricPeriod"].Value = historicPeriod;

            cmd.Parameters.Add("@LocationIdFK", SqlDbType.Int);
            cmd.Parameters["@LocationIdFK"].Value = locationIdFK;

            cmd.Parameters.Add("@OrderFormIdFK", SqlDbType.Int);
            cmd.Parameters["@OrderFormIdFK"].Value = orderFormIdFK;

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }

        public void addOrderForms(DateTime date, String buyerAdress, Int32 buyerIdFk)
        {
            OrderForms ordF = new OrderForms();
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            string qString = "insert into tblOrderForms (Date,BuyerAdress,BuyerIdFk) values (@Date,@BuyerAdress,@BuyerIdFk)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@Date", SqlDbType.DateTime);
            cmd.Parameters["@Date"].Value = date;

            cmd.Parameters.Add("@BuyerAdress", SqlDbType.VarChar);
            cmd.Parameters["@BuyerAdress"].Value = buyerAdress;

            cmd.Parameters.Add("@BuyerIdFk", SqlDbType.Int);
            cmd.Parameters["@BuyerIdFk"].Value = buyerIdFk;



            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }
        }
        public void addUsers(String name,String userName,String password,Boolean isAdministrator)
        {
            OrderForms ordF = new OrderForms();
            SqlConnection conection = new SqlConnection();
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            string qString = "insert into tblUsers (Name,UserName,Password,IsAdministrator) values (@Name,@UserName,@Password,@ISAdministrator)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = qString;
            cmd.Connection = conection;

            cmd.Parameters.Add("@Name", SqlDbType.VarChar);
            cmd.Parameters["@Name"].Value = name;

            cmd.Parameters.Add("@UserName", SqlDbType.VarChar);
            cmd.Parameters["@UserName"].Value = userName;

            cmd.Parameters.Add("@Password", SqlDbType.VarChar);
            cmd.Parameters["@Password"].Value = userName;

            cmd.Parameters.Add("@ISAdministrator", SqlDbType.Bit);
            cmd.Parameters["@ISAdministrator"].Value = isAdministrator;

            


            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception e)
            {
                return;
            }


        }



        public List<Exhibits> getExhibits()
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblExhibits");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Exhibits> exhibits = new List<Exhibits>();

            while (reader.Read())
            {
                Exhibits exhibit = new Exhibits();
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.ExhibitId = Convert.ToInt32(reader["ExhibitId"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.Type = Convert.ToString(reader["Type"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.Dimensions = Convert.ToString(reader["Dimensions"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.HistoricPeriod = Convert.ToString(reader["HistoricPeriod"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.LocationIdFK = Convert.ToInt32(reader["LocationIdFK"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.OrderFormIdFK = Convert.ToInt32(reader["OrderFormIdFK"]);
                }

                exhibits.Add(exhibit);
            }
            return exhibits;
        }

        public List<Buyers> getBuyers()
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblBuyers");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Buyers> buyers = new List<Buyers>();

            while (reader.Read())
            {
                Buyers buyer = new Buyers();
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersId = Convert.ToInt32(reader["BuyerId"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersName = Convert.ToString(reader["BuyersName"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersSurname = Convert.ToString(reader["BuyersSurname"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersAddress = Convert.ToString(reader["BuyersAddress"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersCountry = Convert.ToString(reader["BuyersCountry"]);
                }


                buyers.Add(buyer);
            }
            return buyers;

        }

        public List<Exhibits> findExhibits(String type, String historicPeriod)
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblExhibits where Type = '" + type + "' or HistoricPeriod='" + historicPeriod + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Exhibits> exhibits = new List<Exhibits>();

            while (reader.Read())
            {
                Exhibits exhibit = new Exhibits();
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.ExhibitId = Convert.ToInt32(reader["ExhibitId"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.Type = Convert.ToString(reader["Type"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.Dimensions = Convert.ToString(reader["Dimensions"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.HistoricPeriod = Convert.ToString(reader["HistoricPeriod"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.LocationIdFK = Convert.ToInt32(reader["LocationIdFK"]);
                }
                if (!Convert.IsDBNull(reader["ExhibitId"]))
                {
                    exhibit.OrderFormIdFK = Convert.ToInt32(reader["OrderFormIdFK"]);
                }

                exhibits.Add(exhibit);
            }
            return exhibits;
        }
        public List<Buyers> findBuyers(String buyersName, String buyersSurname)
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblBuyers where BuyersName = '" + buyersName + "' or BuyersSurname='" + buyersSurname + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Buyers> buyers = new List<Buyers>();

            while (reader.Read())
            {
                Buyers buyer = new Buyers();
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersId = Convert.ToInt32(reader["BuyerId"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersName = Convert.ToString(reader["BuyersName"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersSurname = Convert.ToString(reader["BuyersSurname"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersAddress = Convert.ToString(reader["BuyersAddress"]);
                }
                if (!Convert.IsDBNull(reader["BuyerId"]))
                {
                    buyer.BuyersCountry = Convert.ToString(reader["BuyersCountry"]);
                }


                buyers.Add(buyer);
            }
            return buyers;
        }

        public List<Users> findUsers(String name, String userName)
        {
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("select * from tblUsers where Name = '" + name + "' or UserName='" + userName + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            List<Users> users = new List<Users>();

            while (reader.Read())
            {
                Users user = new Users();
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.Name = Convert.ToString(reader["Name"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.UserName = Convert.ToString(reader["UserName"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.Password = Convert.ToString(reader["Password"]);
                }
                if (!Convert.IsDBNull(reader["UserId"]))
                {
                    user.IsAdministrator = Convert.ToBoolean(reader["IsAdministrator"]);
                }


                users.Add(user);
            }
            return users;


        }


        public void deleteExhibits(Int32 exhibitId)
        {

            Exhibits exhi = new Exhibits();
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("delete from tblExhibits where ExhibitId= '" + exhibitId + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Close();
        }

        public void deleteUsers(Int32 userId)
        {

            Users user = new Users();
            SqlConnection conection = new SqlConnection();
            DataSet data = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand query = new SqlCommand("delete from tblUsers where UserId= '" + userId + "'");
            conection.ConnectionString = ("Data Source=DACO-PC;Initial Catalog=Museum;User ID=sa;Password=daco;MultipleActiveResultSets=True");
            query.Connection = conection;
            conection.Open();
            SqlDataReader reader = query.ExecuteReader();
            reader.Close();
        }









    }
}
    
            





        
    
    
    

    
    

