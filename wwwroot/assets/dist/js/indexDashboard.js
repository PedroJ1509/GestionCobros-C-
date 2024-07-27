function IndexDashboard() {

    this.Init = function () {
        self.ConsultaTotales();
        self.BuscarVentasPorMes();
        self.BuscarVentasPorDia ();
        self.BuscarVentasPorArticulo ();
        self.BuscarUltimosCierres();
    }
    this.ConsultaTotales = function() {
        GetAjax("TotalesDashboardInfo/", "json", "", function (data) {
            console.log(data);
            $("#ventas-dia").text(data.ventasDia);
            $("#recibo-dia").text(data.reciboDia);
            $("#total-cxc").text(data.totalCxC);
            $("#total-cxp").text(data.ultimoCierre);
        });
    }
    this.BuscarVentasPorArticulo = function() {
        $("#content-art-vendidos").html('');
        GetAjax("BuscarVentasPorArticulo/", "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<div class="runnigwork">
                                            <span class="label-info label label-default float-right">${currentValue.cantidad}</span>
                                            <i class="fa fa-dot-circle-o"></i>
                                            <a href="#">${currentValue.articuloCd} - ${currentValue.articuloDesc}</a><br>
                                            <div class="progress runningprogress">
                                                <div class="progress-bar progress-bar-striped" role="progressbar" style="width: ${currentValue.porcentaje}%" aria-valuenow="${currentValue.porcentaje}" aria-valuemin="0" aria-valuemax="100" data-toggle="tooltip" data-placement="top" title="" data-original-title="${currentValue.porcentaje}%"></div>
                                            </div>
                                        </div>`
            });
            $("#content-art-vendidos").html(dataHtml);
        });
    }
    this.BuscarUltimosCierres = function() {
        $("#content-cierre-caja").html('');
        GetAjax("BuscarUltimosCierres/", "json", "", function (data) {
            let dataHtml = '';

            data.forEach(function (currentValue, index, arr) {
                dataHtml = dataHtml + `<div class="work-touchpoint">
                                        <div class="work-touchpoint-date">
                                            <span class="day">${currentValue.dia}</span>
                                            <span class="month">${ObtenerNombreMesAbr(currentValue.mes)}</span>
                                        </div>
                                        </div>
                                        <div class="detailswork">
                                            <span class="label-custom label label-default float-right">${currentValue.monto}</span>
                                            <a href="#" title="headings">${currentValue.usuario}</a> <br>
                                            <p>Monto Cierre Efectivo - ${currentValue.efectivo}</p>
                                        </div>`
            });
            $("#content-cierre-caja").html(dataHtml);
        });
    }
    this.BuscarVentasPorDia = function() {
        GetAjax("BuscarVentasPorDia/", "json", "", function (data) {
            let dias = [];
            let montos = [];
            data.forEach(function(currentValue){
                let arrMes = currentValue.fecha.split("-");
                dias.push(currentValue.fecha);
                montos.push(currentValue.total);
            });

            var ctx = document.getElementById("singelBarChart");
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: dias,
                    datasets: [
                        {
                            label: "Total Ventas por Día",
                            data: montos,
                            borderColor: "rgba(0, 150, 136, 0.8)",
                            width: "1",
                            borderWidth: "0",
                            backgroundColor: "rgba(0, 150, 136, 0.8)"
                        }
                    ]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });

        });
    }

    this.BuscarVentasPorMes = function() {
        GetAjax("BuscarVentasPorMes/", "json", "", function (data) {

            let mes = [];
            let montos = [];
            let contado = [];
            let credito = [];
            data.forEach(function(currentValue){
                let arrMes = currentValue.anoMes.split("-");
                mes.push(ObtenerNombreMes(arrMes[1]));
                contado.push(currentValue.ventasContado);
                credito.push(currentValue.ventasCredito);
            });
            
            //bar chart
            var ctx = document.getElementById("barChart");
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: mes,
                    datasets: [
                        {
                            label: "Ventas al Contado",
                            data: contado,
                            borderColor: "rgba(0, 150, 136, 0.8)",
                            width: "1",
                            borderWidth: "0",
                            backgroundColor: "rgba(0, 150, 136, 0.8)"
                        },
                        {
                            label: "Ventas a Crédito",
                            data: credito,
                            borderColor: "rgba(51, 51, 51, 0.55)",
                            width: "1",
                            borderWidth: "0",
                            backgroundColor: "rgba(51, 51, 51, 0.55)"
                        }
                    ]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        });
    }
    

    let self = this;
}

$(document).ready(function(){

    
    const indexdashboard = new IndexDashboard();
    indexdashboard.Init();

});


