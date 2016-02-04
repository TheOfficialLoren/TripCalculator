<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TripCalculator.UI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".Watermark").each(function () {
                SetupWatermark(this);
            });
        });
        function SetupWatermark(object) {
            var inputControl = $(object);
            var title = inputControl.attr("title");

            //Initial setup for watermark elements.
            if (inputControl.val() == "" || inputControl.val() == title) {
                //This is a control that needs watermark setup.
                inputControl.val(title);
                if (!inputControl.hasClass("Watermark")) {
                    inputControl.addClass("Watermark");
                }
            } else {
                inputControl.removeClass("Watermark");
            }

            inputControl.focus(function () {
                //Setup action when watermark elements get focus.
                if (inputControl.val() == "" || inputControl.val() == inputControl.attr("title")) {
                    inputControl.val('');
                    inputControl.removeClass("Watermark");
                }
            });

            inputControl.blur(function () {
                //Setup watermark action when elements loses focus.
                if (inputControl.val() == title || inputControl.val() == "") {
                    //No value has been entered.
                    inputControl.val(inputControl.attr("title"));
                    inputControl.addClass("Watermark");
                }
            });
        }

        function SubmitClick() {
            $("#response").text("");
            $(".warn").remove();
            var students = [];
            var badNumbers = false;
            $(".student").each(function () {
                var name = $(".studentName", this).val();
                if (name != "") {
                    //We have a student's name
                    var student = {};
                    student.Name = name;
                    student.Expenses = [];

                    //Now grab any expenses that might exist for this student.
                    $(".trExpense", this).each(function () {
                        var inputs = $("input", this);
                        if (inputs[0].value != "" && inputs[0].value != "Description") {
                            var expense = {};
                            expense.Name = inputs[0].value;

                            if (isNaN(inputs[1].value)) {
                                $(inputs[1]).after("<span class='warn'>This is not a number</span>");
                                badNumbers = true;
                            }

                            expense.Amount = inputs[1].value;
                            student.Expenses.push(expense);
                        }
                    });

                    students.push(student);
                }

            });
            if (badNumbers) {
                $("#response").text("Please fix the incorrect amounts above.");
                return;
            }
            else if (students.length == 0) {
                $("#response").text("No students entered!");
                return;
            }
            var request = {};
            request.Students = students;
            var loadingImg = $("#LoadingImg");
            $.ajax({
                type: "POST",
                url: "WebService.asmx/CalculateExpenses",
                mimeType: "text/html",
                data: JSON.stringify({ 'request': request }),
                contentType: "application/json; charset=utf-8;",
                dataType: "json", //specifies response type
                beforeSend: function () {
                    $(loadingImg).show();
                },
                success: function (response) {
                    if (response != null && response.d != undefined) {
                        if (response.d.PaymentsDue.length > 0) {
                            $(response.d.PaymentsDue).each(function () {
                                $("#response").text($("#response").text() + " " + this.From + " should pay " + this.To + " " + this.Amount.toMoney() + ".");
                            });
                        } else {
                            $("#response").text("No payments due.");
                        }
                    } else {
                        $("#response").text("No response from server.");
                    }
                    $(loadingImg).hide();
                },
                error: function (xml, textStatus, errorThrown) {
                    $("#response").text("Error: " + errorThrown);
                    $(loadingImg).hide();
                }
            });


        }

        Number.prototype.toMoney = function (decimals, decimalSep, thousandsSep) {
            var n = this,
                    c = isNaN(decimals) ? 2 : Math.abs(decimals),
                    d = decimalSep || '.',
                    t = (typeof thousandsSep === 'undefined') ? ',' : thousandsSep,
                    sign = (n < 0) ? '-' : '',
                    i = parseInt(n = Math.abs(n).toFixed(c)) + '',
                    j = ((j = i.length) > 3) ? j % 3 : 0;
            return sign + "$" + (j ? i.substr(0, j) + t : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : '');
        };
    </script>
</asp:Content>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Trip Calculator</h1>
    </div>

    <div class="row">
        <div class="col-md-4 student">
            <table>
                <tr>
                    <td colspan="2">Student 1 Name
                    </td>
                    <td>
                        <input type="text" class="studentName Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 1
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 2
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 3
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 4
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-md-4 student">
            <table>
                <tr>
                    <td colspan="2">Student 2 Name
                    </td>
                    <td>
                        <input type="text" class="studentName Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 1
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 2
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 3
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 4
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="col-md-4 student">
            <table>
                <tr>
                    <td colspan="2">Student 3 Name
                    </td>
                    <td>
                        <input type="text" class="studentName Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 1
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 2
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 3
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
                <tr class="trExpense">
                    <td>Expense 4
                    </td>
                    <td>
                        <input type="text" title="Description" class="Watermark" />
                    </td>
                    <td>
                        <input type="text" title="Amount" class="Watermark" />
                    </td>
                </tr>
            </table>
        </div>

    </div>
    <input type="button" value="Submit" onclick="SubmitClick();" style="margin-top: 30px" />
    <img style="display: none" id="LoadingImg" src="Content/pacman.gif" />
    <span id="response" style="color: red;"></span>
</asp:Content>
