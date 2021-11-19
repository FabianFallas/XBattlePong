using NUnit.Framework;
using System;
using XBattlePongRestAPI.Controllers;
using XBattlePongRestAPI.DataAccessAndDBContext;
using XBattlePongRestAPI.Models;
using XBattlePongRestAPI.Utils;

namespace UnitTests
{
    public class utilsAndAccessProviderTests
    {
        TokenManager tokenManager;
        private readonly IEventosAccessProvider _dataAccessProvider; 
        [SetUp]
        public void Setup()
        {
            tokenManager = new TokenManager();
            
        }
        [Test]
        public void isInEventDays_InRangeWorks()
        {
            //Arrange
            //  10/11/2021 19:00:00 P.M
            DateTime deadline = new DateTime(2021, 11, 10, 19, 0, 0);

            //Act
            bool isInEventDays = tokenManager.isInEventDays(deadline);

            //Assert
            Assert.IsFalse(isInEventDays);

        }
        [Test]
        public void isInEventDays_NotInRangeWorks()
        {
            //Arrange
            //  10/11/2022 19:00:00 P.M
            DateTime deadline2 = new DateTime(2022, 11, 10, 19, 0, 0);

            //Act
            bool IsInEventDays = tokenManager.isInEventDays(deadline2);

            //Assert
            Assert.IsTrue(IsInEventDays);
        }
        [Test]
        public void AddEventosRecord_Works() {

            Eventos evento = new Eventos();
            /*
            evento.nombrePartida = "AokiFest";
            evento.fechaDeInicio = "2021-11-19";
            evento.horaDeInicioSTR = "18:18";
            evento.fechaDeFinalizacion=;
            evento.horaDeFinalizacionSTR=;
            evento.pais=;
            evento.localidad=;
            evento.codigoDeEvento=;
            evento.nombreDeOrganizador=;


            {
    nombrePartida: "HardstyleFest",
    fechaDeInicio: "2021-11-19",
    horaDeInicioSTR: "17:17",
    fechaDeFinalizacion: "2021-11-22",
    horaDeFinalizacionSTR: "17:17",
    pais: "Chile",
    localidad: "Centro",
    codigoDeEvento: "CH222CH222",
    nombreDeOrganizador: "Hardwell"
};
            */

            _dataAccessProvider.AddEventosRecord(evento);

        }


    }
}
