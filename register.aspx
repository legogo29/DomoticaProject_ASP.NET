<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="DomoticaProject.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

        <div>

         <div class="container">
			<div class="row main">
				<div class="panel-heading">
	               <div class="panel-title text-center">
	               		<h1 class="title">Registreer</h1>
	               		<hr />
	               	</div>
	            </div> 
				<div class="main-login main-center">
                    
					<!--<form class="form-horizontal"> -->
						
						<div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Uw voornaam</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                    <asp:TextBox ID="input_voornaam" runat="server" CssClass="form-control" placeholder ="Enter your First Name"></asp:TextBox>
								</div>
							</div>
						</div>

                        <div class="form-group">
							<label for="name" class="cols-sm-2 control-label">Uw achternaam</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-user-o" aria-hidden="true"></i></span>
                                    <asp:TextBox ID="input_achternaam" runat="server" CssClass ="form-control" placeholder ="Enter your Last Name"></asp:TextBox>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="email" class="cols-sm-2 control-label">Uw Email</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                                    <asp:TextBox ID="input_email" runat="server" CssClass ="form-control" placeholder ="Enter your Email"></asp:TextBox>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="username" class="cols-sm-2 control-label">Uw gebruikersnaam</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                                    <asp:TextBox ID="input_displayname" runat="server" CssClass ="form-control" placeholder ="Enter your Username"></asp:TextBox>
								</div>
							</div>
						</div>

						<div class="form-group">
							<label for="password" class="cols-sm-2 control-label">Uw wachtwoord</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="password" id="input_passwordA"  placeholder="Enter your Password" runat ="server"/>
                                </div>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare= "input_passwordB" ControlToValidate="input_passwordA" ErrorMessage="Wachtwoord komt niet overeen"></asp:CompareValidator>
							</div>
						</div>

						<div class="form-group">
							<label for="confirm" class="cols-sm-2 control-label">Bevestig wachtwoord</label>
							<div class="cols-sm-10">
								<div class="input-group">
									<span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
									<input type="password" class="form-control" name="confirm" id="input_passwordB"  placeholder="Confirm your Password" runat ="server"/>
								</div>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare= "input_passwordA" ControlToValidate="input_passwordB" ErrorMessage="Wachtwoord komt niet overeen"></asp:CompareValidator>
							</div>
						</div>

						<div class="form-group ">
                            <asp:Button ID="button" runat="server" Text="Registeer" OnClick="button_Click" CssClass="btn btn-primary btn-lg btn-block login-button"  />
						</div>
						
					<!--</form> -->
				</div>
			</div>
		</div>

    
    </div>

</asp:Content>
