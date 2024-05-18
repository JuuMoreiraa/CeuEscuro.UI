using CeuEscuro.BLL;
using CeuEscuro.DTO;
using CeuEscuro.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.adm
{
    public partial class ManageUser : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objDTO = new UsuarioDTO();

        //pageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtIdUsuario.Enabled = false;
                PopularGv1();
                PopularDDL1();
            }

        }

        //Popular gv1
        public void PopularGv1()
        {
            gv1.DataSource = objBLL.GetUsersAll();
            gv1.DataBind();
        }

        //Popular ddl1
        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.LoadDropListUs();
            ddl1.DataBind();
        }

        //validapage
        public bool ValidaPage()
        {
            bool valid;
            DateTime dt;
            if (string.IsNullOrEmpty(txtNomeUsuario.Text))
            {
                lblNomeUsuario.Text = "$Digite um nome !!";
                txtNomeUsuario.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtEmailUsuario.Text))
            {
                lblEmailUsuario.Text = "$Digite um email !!";
                txtEmailUsuario.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtSenhaUsuario.Text))
            {
                lblSenhaUsuario.Text = "$Digite uma senha !!";
                txtSenhaUsuario.Focus();
                valid = false;
            }
            else if (string.IsNullOrEmpty(txtDtNascUsuario.Text) || (!DateTime.TryParse(txtDtNascUsuario.Text, out dt)))
            {
                lblDtNascUsuario.Text = "$Digite uma data de nascimento !!";
                txtDtNascUsuario.Text = string.Empty;
                txtDtNascUsuario.Focus();
                valid = false;
            }
            else
            {
                valid = true;
            }
            return valid;
        }

        //btnClear
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear.ClearControl(this);
            txtSearch.Focus();
        }
        //gv1
        protected void gv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int usuarioId = int.Parse(gv1.SelectedRow.Cells[1].Text);
            objDTO = objBLL.GetById(usuarioId);
            txtIdUsuario.Text = objDTO.IdUsuario.ToString();
            txtNomeUsuario.Text = objDTO.NomeUsuario.ToString();
            txtEmailUsuario.Text = objDTO.EmailUsuario.ToString();
            txtSenhaUsuario.Text = objDTO.SenhaUsuario.ToString();
            txtDtNascUsuario.Text = objDTO.DtNascUsuario.ToString("dd/MM/yyyy");
            ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();
            PopularGv1();
        }

        protected void btnRecord_Click(object sender, EventArgs e)
        {
            if (ValidaPage())
            {
                objDTO.NomeUsuario = txtNomeUsuario.Text.Trim();
                objDTO.EmailUsuario = txtEmailUsuario.Text.Trim();
                objDTO.SenhaUsuario = txtSenhaUsuario.Text.Trim();

                DateTime dt = DateTime.Parse(txtDtNascUsuario.Text.Trim());
                objDTO.DtNascUsuario = dt;
                objDTO.TipoUsuario_Id = ddl1.SelectedValue;

                if (string.IsNullOrEmpty(txtIdUsuario.Text.Trim()))
                {
                    objBLL.CreateUser(objDTO);
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    PopularGv1();
                    lblMessage.Text = $" Usuário {objDTO.NomeUsuario.ToUpper()} cadastrado com sucesso.";
                }
                else
                {
                    objDTO.IdUsuario = int.Parse(txtIdUsuario.Text);
                    objBLL.UpdateUser(objDTO);
                    Clear.ClearControl(this);
                    txtSearch.Focus();
                    PopularGv1();
                    lblMessage.Text = $" Usuário {objDTO.NomeUsuario.ToUpper()} atualizado com sucesso.";
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objDTO.IdUsuario = int.Parse(txtIdUsuario.Text);
            objBLL.DeleteUser(objDTO.IdUsuario);
            Clear.ClearControl(this);
            txtSearch.Focus();
            PopularGv1();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string usuarioNome = txtSearch.Text.Trim();
            objDTO = objBLL.GetByName(usuarioNome);
            if (string.IsNullOrEmpty(usuarioNome))
            {
                lblSearch.Text = "Campo Vazio";
                txtSearch.Text = string.Empty;
                return;
            }
            else if (objDTO.NomeUsuario == null)
            {
                lblSearch.Text = "Usuário não cadastrado";
                txtSearch.Text = string.Empty;
                return;
            }
            else
            {
                txtIdUsuario.Text = objDTO.IdUsuario.ToString();
                txtNomeUsuario.Text = objDTO.NomeUsuario.ToString();
                txtEmailUsuario.Text = objDTO.EmailUsuario.ToString();
                txtSenhaUsuario.Text = objDTO.SenhaUsuario.ToString();
                txtDtNascUsuario.Text = objDTO.DtNascUsuario.ToString("dd/MM/yyyy");
                ddl1.SelectedValue = objDTO.TipoUsuario_Id.ToString();
                txtSearch.Text = lblSearch.Text = string.Empty;
                txtNomeUsuario.Focus();
            }

        }
    }
}