using Data.Mapping;
using NHibernate;
namespace Data.FluentySession    
{ 
        public static class SessionFact  
        {  
            private static IFluentySessionFactory frameworkSessionFactory;  
            private static IFluentySessionFactory frameworkSessionFactoryInput; 
            private static IFluentySessionFactory frameworkSessionFactoryOutPut; 
  
            public static ISessionFactory GetSessionFact()  
            {  
                if (frameworkSessionFactory == null)  
                {  
                    var connectionStringMySQL = "Server = acesso.cyzeslms577w.us-east-2.rds.amazonaws.com; Port = 3306; Database = Acesso; Uid = O2Si; Pwd = O2SiT3cnologia";
                    frameworkSessionFactory = new FluentySessionFactory<UsuarioMap>(connectionStringMySQL, "mysql");                                                 
                }   
                return frameworkSessionFactory.CreateSessionFactory();    
            }   

            public static ISessionFactory GetSessionFactInput()   
            {   
                if (frameworkSessionFactoryInput == null)   
                {    
                    var connectionStringMySQL = "Server =instituicaodeeducacao.cyzeslms577w.us-east-2.rds.amazonaws.com; Port=3306; Database=InstituicaodeEducacao; Uid=O2Siadmin; Pwd =123O2Siadmin123";     
                    frameworkSessionFactoryInput = new FluentySessionFactory<O2sicontroleMap>(connectionStringMySQL, "mysql");                                                 
                }  
                return frameworkSessionFactoryInput.CreateSessionFactory();   
            }   

            public static ISessionFactory GetSessionFactOutput()   
            {   
                if (frameworkSessionFactoryOutPut == null)   
                {   
                    var connectionStringMySQL = "Server =instituicaodeeducacao.cyzeslms577w.us-east-2.rds.amazonaws.com; Port=3306; Database=InstituicaodeEducacao; Uid=O2Siadmin; Pwd =123O2Siadmin123";     
                    frameworkSessionFactoryOutPut = new FluentySessionFactory<O2sicontroleMap>(connectionStringMySQL, "mysql");                                                 
                }   
                return frameworkSessionFactoryOutPut.CreateSessionFactory();   
            }   
        }       
    }   
