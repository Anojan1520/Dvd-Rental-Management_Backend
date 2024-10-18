using System.Data.SqlClient;

namespace WebApplication1.Database
{
    public class DatabaseInitialize
    {
        private readonly string _ConnectionString;

        public DatabaseInitialize(string connectionstring)
        {
            _ConnectionString = connectionstring;
        }

        public void Initialize()
        {

            using (var SqlConnection = new SqlConnection(_ConnectionString))
            {
                SqlConnection.Open();

                var Command = SqlConnection.CreateCommand();
                Command.CommandText = @"
                  IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
                              BEGIN
                                      CREATE TABLE Users (
                                       id UNIQUEIDENTIFIER PRIMARY KEY,
                                       position NVARCHAR(10) NOT NULL,
                                       firstname NVARCHAR(20) NOT NULL ,
                                       username NVARCHAR(20) NOT NULL UNIQUE,
                                       password NVARCHAR(200) NOT NULL,
                                       nic NVARCHAR(20) NOT NULL,
                                       phone INT NOT NULL,
                                       email NVARCHAR(20) NOT NULL,
                              );
                               END
                ";
                Command.ExecuteNonQuery();


                Command.CommandText = @"
                    IF NOT EXISTS(SELECT * FROM sys.tables where name = 'Movies')
                              BEGIN 
                                 CREATE TABLE Movies (
                                        id UNIQUEIDENTIFIER PRIMARY KEY ,
                                        Name NVARCHAR(20)  NOT NULL, 
                                        Genere NVARCHAR(29)  NOT NULL,
                                        Director NVARCHAR(20) NOT NULL ,
                                        Actor NVARCHAR(20)  NOT NULL, 
                                        Release NVARCHAR(20)  NOT NULL,
                                        Images NVARCHAR(600)  NOT NULL,
                                        Quantity INT  NOT NULL,
                                        Price DECIMAL(10,3)  NOT NULL,
                                                        );
                               END
                ";
                Command.ExecuteNonQuery();

                Command.CommandText = @"
                   IF NOT EXISTS ( SELECT  * FROM sys.tables where name = 'LoginUsers')
                               BEGIN 
                                       CREATE TABLE LoginUsers (
                                              id UNIQUEIDENTIFIER PRIMARY KEY ,
                                              username NVARCHAR(20)  NOT NULL ,
                                              password NVARCHAR(150)  NOT NULL, 
                                              CONSTRAINT FK_LoginUsers_Users FOREIGN KEY (username) REFERENCES Users(username) );
                               END";
                Command.ExecuteNonQuery();

                Command.CommandText = @"
                  IF NOT EXISTS (SELECT * FROM sys.tables where name = 'RentedItems' )
                    BEGIN
                        CREATE TABLE RentedItems (
                                      id UNIQUEIDENTIFIER PRIMARY KEY  NOT NULL,
                                      MovieId UNIQUEIDENTIFIER  NOT NULL,
                                      UserId UNIQUEIDENTIFIER  NOT NULL,
                                      Status NVARCHAR(20)   NOT NULL,
                                      RentedQuantity INT   NOT NULL,
                                      RentDate NVARCHAR(30)  NOT NULL,
                                      ReturnDate NVARCHAR(30)   NOT NULL,

                              CONSTRAINT FK_RentedItems_Movies FOREIGN KEY (MovieId) REFERENCES  Movies(id),
                              CONSTRAINT FK_RentedItems_Users FOREIGN KEY (UserId) REFERENCES  Users(id)

                            
                         );
                    END
                ";
                Command.ExecuteNonQuery();
                              

                Command.CommandText = @"
                   IF NOT EXISTS (SELECT * FROM sys.tables where name = 'Notification')
                           BEGIN 
                             CREATE TABLE Notification(
                                id UNIQUEIDENTIFIER PRIMARY KEY ,
                                RentedId UNIQUEIDENTIFIER  NOT NULL,
                                RentedQuantity  INT  NOT NULL,
                                movieId UNIQUEIDENTIFIER  NOT NULL,
                                UserId UNIQUEIDENTIFIER  NOT NULL,
                                RequestDate NVARCHAR(20)  NOT NULL,
                                Status NVARCHAR(20)   NOT NULL,

                         CONSTRAINT  FK_Notification_Movies FOREIGN KEY (MovieId) REFERENCES  Movies(id),
                         CONSTRAINT  FK_Notification_Users FOREIGN KEY (UserId) REFERENCES  Users(id)
                             ); 
                          END
                "; 
                Command.ExecuteNonQuery();

               
            }

        }



    }
}
