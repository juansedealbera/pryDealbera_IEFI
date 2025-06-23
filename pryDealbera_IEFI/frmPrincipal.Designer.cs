namespace pryDealbera_IEFI
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTarea = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistorial = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAdministración = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAuditoria = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMenu = new System.Windows.Forms.StatusStrip();
            this.lblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.menu.SuspendLayout();
            this.statusStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem,
            this.tsmAdministración});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(536, 28);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // tareasToolStripMenuItem
            // 
            this.tareasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTarea,
            this.mnuHistorial});
            this.tareasToolStripMenuItem.Image = global::pryDealbera_IEFI.Properties.Resources.documento;
            this.tareasToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            this.tareasToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.tareasToolStripMenuItem.Text = "Tareas";
            // 
            // mnuTarea
            // 
            this.mnuTarea.Name = "mnuTarea";
            this.mnuTarea.Size = new System.Drawing.Size(153, 22);
            this.mnuTarea.Text = "Registrar Tarea";
            this.mnuTarea.Click += new System.EventHandler(this.registrarTareaToolStripMenuItem_Click);
            // 
            // mnuHistorial
            // 
            this.mnuHistorial.Name = "mnuHistorial";
            this.mnuHistorial.Size = new System.Drawing.Size(153, 22);
            this.mnuHistorial.Text = "Historial Tareas";
            this.mnuHistorial.Click += new System.EventHandler(this.historialTareasToolStripMenuItem_Click);
            // 
            // tsmAdministración
            // 
            this.tsmAdministración.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuarios,
            this.mnuAuditoria});
            this.tsmAdministración.Image = global::pryDealbera_IEFI.Properties.Resources.trabajo_en_equipo;
            this.tsmAdministración.Name = "tsmAdministración";
            this.tsmAdministración.Size = new System.Drawing.Size(120, 24);
            this.tsmAdministración.Text = "Administración";
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(123, 22);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // mnuAuditoria
            // 
            this.mnuAuditoria.Name = "mnuAuditoria";
            this.mnuAuditoria.Size = new System.Drawing.Size(123, 22);
            this.mnuAuditoria.Text = "Auditoria";
            this.mnuAuditoria.Click += new System.EventHandler(this.auditoriaToolStripMenuItem_Click);
            // 
            // statusStripMenu
            // 
            this.statusStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUser,
            this.lblFecha,
            this.lblTiempo});
            this.statusStripMenu.Location = new System.Drawing.Point(0, 341);
            this.statusStripMenu.Name = "statusStripMenu";
            this.statusStripMenu.Size = new System.Drawing.Size(536, 22);
            this.statusStripMenu.TabIndex = 1;
            this.statusStripMenu.Text = "statusTripInicio";
            // 
            // lblUser
            // 
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(173, 17);
            this.lblUser.Spring = true;
            this.lblUser.Text = "User";
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(173, 17);
            this.lblFecha.Spring = true;
            this.lblFecha.Text = "Fecha";
            // 
            // lblTiempo
            // 
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(173, 17);
            this.lblTiempo.Spring = true;
            this.lblTiempo.Text = "Tiempo de Actividad";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick_1);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(536, 363);
            this.Controls.Add(this.statusStripMenu);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStripMenu.ResumeLayout(false);
            this.statusStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAdministración;
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuAuditoria;
        private System.Windows.Forms.StatusStrip statusStripMenu;
        private System.Windows.Forms.ToolStripStatusLabel lblUser;
        private System.Windows.Forms.ToolStripStatusLabel lblFecha;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempo;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem mnuTarea;
        private System.Windows.Forms.ToolStripMenuItem mnuHistorial;
    }
}

