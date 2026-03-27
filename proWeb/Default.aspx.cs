using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using library;

namespace proWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            CADCategory cadCategory = new CADCategory();
            var categories = cadCategory.readAll();
            ddlCategory.Items.Clear();
            foreach (var cat in categories)
            {
                ddlCategory.Items.Add(new ListItem(cat.Name, cat.Id.ToString()));
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;
                en.Name = txtName.Text;
                en.Amount = int.Parse(txtAmount.Text);
                en.Price = float.Parse(txtPrice.Text);
                en.Category = int.Parse(ddlCategory.SelectedValue);
                en.CreationDate = DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", null);

                ENProduct existing = new ENProduct();
                existing.Code = en.Code;
                if (existing.Read())
                {
                    lblMessage.Text = "Error: ya existe un producto con ese código.";
                    return;
                }

                if (en.Create())
                    lblMessage.Text = "Producto creado correctamente.";
                else
                    lblMessage.Text = "Error al crear el producto.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (!en.Read())
                {
                    lblMessage.Text = "Error: no existe un producto con ese código.";
                    return;
                }

                en.Name = txtName.Text;
                en.Amount = int.Parse(txtAmount.Text);
                en.Price = float.Parse(txtPrice.Text);
                en.Category = int.Parse(ddlCategory.SelectedValue);
                en.CreationDate = DateTime.ParseExact(txtCreationDate.Text, "dd/MM/yyyy HH:mm:ss", null);

                if (en.Update())
                    lblMessage.Text = "Producto actualizado correctamente.";
                else
                    lblMessage.Text = "Error al actualizar el producto.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (!en.Read())
                {
                    lblMessage.Text = "Error: no existe un producto con ese código.";
                    return;
                }

                if (en.Delete())
                {
                    lblMessage.Text = "Producto eliminado correctamente.";
                    txtCode.Text = "";
                    txtName.Text = "";
                    txtAmount.Text = "";
                    txtPrice.Text = "";
                    txtCreationDate.Text = "";
                }
                else
                    lblMessage.Text = "Error al eliminar el producto.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.Read())
                {
                    txtName.Text = en.Name;
                    txtAmount.Text = en.Amount.ToString();
                    txtPrice.Text = en.Price.ToString();
                    txtCreationDate.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    ddlCategory.SelectedValue = en.Category.ToString();
                    lblMessage.Text = "Producto leído correctamente.";
                }
                else
                    lblMessage.Text = "Error: no existe un producto con ese código.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();

                if (en.ReadFirst())
                {
                    txtCode.Text = en.Code;
                    txtName.Text = en.Name;
                    txtAmount.Text = en.Amount.ToString();
                    txtPrice.Text = en.Price.ToString();
                    txtCreationDate.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    ddlCategory.SelectedValue = en.Category.ToString();
                    lblMessage.Text = "Primer producto leído correctamente.";
                }
                else
                    lblMessage.Text = "Error: no hay productos en la base de datos.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.ReadPrev())
                {
                    txtCode.Text = en.Code;
                    txtName.Text = en.Name;
                    txtAmount.Text = en.Amount.ToString();
                    txtPrice.Text = en.Price.ToString();
                    txtCreationDate.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    ddlCategory.SelectedValue = en.Category.ToString();
                    lblMessage.Text = "Producto anterior leído correctamente.";
                }
                else
                    lblMessage.Text = "Error: no hay producto anterior.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct();
                en.Code = txtCode.Text;

                if (en.ReadNext())
                {
                    txtCode.Text = en.Code;
                    txtName.Text = en.Name;
                    txtAmount.Text = en.Amount.ToString();
                    txtPrice.Text = en.Price.ToString();
                    txtCreationDate.Text = en.CreationDate.ToString("dd/MM/yyyy HH:mm:ss");
                    ddlCategory.SelectedValue = en.Category.ToString();
                    lblMessage.Text = "Producto siguiente leído correctamente.";
                }
                else
                    lblMessage.Text = "Error: no hay producto siguiente.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}