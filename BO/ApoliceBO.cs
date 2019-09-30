using DAO;
using DTO;
using System;
using System.Collections.Generic;
namespace BO
{
    public class ApoliceBO
    {
        public void CriarApolice(ApoliceDTO apolice)
        {
            ApoliceDAO apoliceDAO = new ApoliceDAO();
            apoliceDAO.CriarApolice(ref apolice);
        }

        public List<ApoliceDTO> PesquisarApolice(ApoliceDTO apolice)
        {
            ApoliceDAO apoliceDAO = new ApoliceDAO();
            return apoliceDAO.PesquisarApolice(apolice);
        }

        public ApoliceDTO PesquisarApolicePorID(ApoliceDTO apolice)
        {
            ApoliceDAO apoliceDAO = new ApoliceDAO();
            return apoliceDAO.PesquisarApolicePorID(apolice)[0];
        }

        public List<ApoliceDTO> PesquisarApoliceTodas()
        {
            ApoliceDAO apoliceDAO = new ApoliceDAO();
            return apoliceDAO.PesquisarApoliceTodas();
        }

        public void ExcluirApolice(ApoliceDTO apolice)
        {
            ApoliceDAO apoliceDAO = new ApoliceDAO();
            apoliceDAO.ExcluirApolice(ref apolice);
        }
        
        public void AlterarApolice(ApoliceDTO apolice)
        {
            ApoliceDAO apoliceDAO = new ApoliceDAO();
            apoliceDAO.AlterarApolice(ref apolice);
        }
    }
}
