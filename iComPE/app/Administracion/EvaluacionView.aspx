<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EvaluacionView.aspx.cs" 
    Inherits="app_Administracion_EvaluacionView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <h2>Evaluación a docente</h2>
        <h6>Yuri, estás evaluando al docente Julián Lara de la materia Ciencias Exactas II</h6>
        <!--Form ITEM-->

        <div class="box">
            <div class="box-header bg-transparent">
                <!-- tools box -->
                <div class="pull-right box-tools">
                    <span class="box-btn" data-widget="collapse"><i class="icon-minus"></i>
                    </span>
                </div>
                <h3 class="box-title"><i class="fontello-th-outline"></i>
                    <span>Hoja 1</span>
                </h3>
            </div>
            <!-- /.box-header -->
            <div class="box-body " style="display: block;">
                <table id="footable-res2" class="demo" data-filter="#filter" data-filter-text-only="true">
                    <thead>
                        <tr>
                            <th></th>
                            <th>Pregunta</th>
                            <th>Calificación</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                        <tr>
                            <td>4</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                        <tr>
                            <td>5</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                        <tr>
                            <td>6</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                        <tr>
                            <td>7</td>
                            <td>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla vel dolor tempus felis semper egestas. Ut nec erat id diam tristique consequat at ac enim.</td>
                            <td>
                                <input type="text" placeholder=""></td>
                        </tr>
                    </tbody>
                </table>
                <br>
            </div>
            <!-- end .timeline -->
        </div>
        <!-- box -->

        <div class="box">
        </div>

        </div>
    
</asp:Content>

