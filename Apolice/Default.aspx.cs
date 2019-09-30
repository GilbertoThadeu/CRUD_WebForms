using BO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Apolice
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaGridEdropdown();
                LimpaCampos();                
            }
            aviso.InnerText = "";
        }

        protected void Criar_Click(object sender, EventArgs e)
        {
            ApoliceBO apoliceBO = new ApoliceBO();
            Page page = HttpContext.Current.Handler as Page;

            try
            {
                apoliceBO.CriarApolice(CarregaApoliceCriar());
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Apólice criada com sucesso');", true);
                CarregaGridEdropdown();
                LimpaCampos();
            }
            catch (Exception ex)
            {
                aviso.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Excluir_Click(object sender, EventArgs e)
        {
            ApoliceBO apoliceBO = new ApoliceBO();
            Page page = HttpContext.Current.Handler as Page;
            try
            {
                apoliceBO.ExcluirApolice(CarregaApoliceExcluir());
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Apólice excluida com sucesso');", true);
                CarregaGridEdropdown();
            }
            catch (Exception ex)
            {
                aviso.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Pesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                ApoliceBO apoliceBO = new ApoliceBO();
                if (txtPesquisarNumeroApolice.Text.Equals(string.Empty))
                    gvApolice.DataSource = apoliceBO.PesquisarApoliceTodas();
                else
                    gvApolice.DataSource = apoliceBO.PesquisarApolice(CarregaApolicePesquisar());
                gvApolice.DataBind();
            }
            catch (Exception ex)
            {
                aviso.InnerText = ex.Message;
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + ex.Message + "');", true);
            }
        }        

        protected void AlterarApolice_Click(object sender, EventArgs e)
        {
            Page page = HttpContext.Current.Handler as Page;
            try
            {                
                ApoliceBO apoliceBO = new ApoliceBO();
                apoliceBO.AlterarApolice(CarregaApoliceAlterar());

                apoliceBO.AlterarApolice(CarregaApoliceAlterar());
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Apólice alterada com sucesso.');", true);
                CarregaGridEdropdown();
                LimpaCampos();
            }
            catch (Exception ex)
            {
                aviso.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + ex.Message + "');", true);
            }
        }

        private void LimpaCampos()
        {
            txtNumeroApolice.Text = "";
            txtCpfCnpj.Text = "";
            txtPlacaVeiculo.Text = "";
            txtValorPremio.Text = "";

            txtAlterarNumeroApolice.Text = "";
            txtAlterarCpfCnpj.Text = "";
            txtAlterarPlacaVeiculo.Text = "";
            txtAlterarValorPremio.Text = "";

            txtExcluirNumeroApolice.Text = "";
            txtPesquisarNumeroApolice.Text = "";
        }

        private void CarregaGridEdropdown()
        {
            try
            {                
                ApoliceBO apoliceBO = new ApoliceBO();
                List<ApoliceDTO> apolices = apoliceBO.PesquisarApoliceTodas();

                gvApolice.DataSource = apolices;
                gvApolice.DataBind();

                ddlApolice.DataSource = apolices;
                ddlApolice.DataValueField = "ID";
                ddlApolice.DataTextField = "NumeroApolice";
                ddlApolice.DataBind();
                ddlApolice.Items.Insert(0,new System.Web.UI.WebControls.ListItem("Selecione a apólice para alterar", "-1"));
            }
            catch (Exception ex)
            {
                aviso.InnerText = ex.Message;
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + ex.Message + "');", true);
            }
        }

        protected void Apolice_SelectedIndexChanged(object sender, EventArgs e)
        {            
            Page page = HttpContext.Current.Handler as Page;
            try
            {
                ApoliceBO apoliceBO = new ApoliceBO();
                ApoliceDTO apolice = new ApoliceDTO();
                apolice.ID = Convert.ToInt32(ddlApolice.SelectedValue);
                apolice = apoliceBO.PesquisarApolicePorID(apolice);
                CarregaCamposAlterar(apolice);
            }
            catch (Exception ex)
            {
                aviso.InnerText = ex.Message;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + ex.Message + "');", true);
            }
        }

        private ApoliceDTO CarregaApoliceAlterar()
        {
            ApoliceDTO apolice = new ApoliceDTO();

            apolice.ID = Convert.ToInt32(ddlApolice.SelectedValue);
            apolice.NumeroApolice = Convert.ToInt32(txtAlterarNumeroApolice.Text);
            apolice.CpfCnpj = Convert.ToInt64(txtAlterarCpfCnpj.Text);
            apolice.PlacaVeiculo = txtAlterarPlacaVeiculo.Text;
            apolice.ValorPremio = Convert.ToDouble(txtAlterarValorPremio.Text.ToString().Replace(".", ","));

            return apolice;
        }

        private void CarregaCamposAlterar(ApoliceDTO apolice)
        {
            txtAlterarNumeroApolice.Text = Convert.ToString(apolice.NumeroApolice);
            txtAlterarCpfCnpj.Text = Convert.ToString(apolice.CpfCnpj);
            txtAlterarPlacaVeiculo.Text = apolice.PlacaVeiculo;
            txtAlterarValorPremio.Text = Convert.ToString(apolice.ValorPremio);
        }

        protected void gvApolice_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
        
        private ApoliceDTO CarregaApolicePesquisar()
        {
            ApoliceDTO apolice = new ApoliceDTO();

            apolice.ID = 0;
            apolice.NumeroApolice = Convert.ToInt32(txtPesquisarNumeroApolice.Text);
            apolice.CpfCnpj = 0;
            apolice.PlacaVeiculo = "";
            apolice.ValorPremio = 0.0;

            return apolice;
        }

        private ApoliceDTO CarregaApoliceCriar()
        {
            ApoliceDTO apolice = new ApoliceDTO();

            apolice.ID = 0;
            apolice.NumeroApolice = Convert.ToInt32(txtNumeroApolice.Text);
            apolice.CpfCnpj = Convert.ToInt64(txtCpfCnpj.Text);
            apolice.PlacaVeiculo = txtPlacaVeiculo.Text;
            apolice.ValorPremio = Convert.ToDouble(txtValorPremio.Text.ToString().Replace(".", ","));

            return apolice;
        }        

        private ApoliceDTO CarregaApoliceExcluir()
        {
            ApoliceDTO apolice = new ApoliceDTO();

            apolice.ID = 0;
            apolice.NumeroApolice = Convert.ToInt32(txtExcluirNumeroApolice.Text);
            apolice.CpfCnpj = 0;
            apolice.PlacaVeiculo = "";
            apolice.ValorPremio = 0.0;

            return apolice;
        }
    }
}
