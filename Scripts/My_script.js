var Faculties = []
function LoadFaculty(element) {
    if (Faculties.length == 0) {
        $.ajax({
            type: "GET",
            url: '/Order/getBookFaculties',
            success: function (data) {
                Faculties = data;
                renderFaculty(element);
            }
        })
    }
    else {
        renderFaculty(element);
    }
}
function renderFaculty(element) {
    var $ele = $(element);
    $ele.empty()
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(Faculties, function (i, val) {
        $ele.append($('<option/>').val(val.FacultyId).text(val.Name));
    })
}


function LoadBook(FacultyDD) {

    $.ajax({
        type: "GET",
        url: '/Order/getBooks',
        data: { 'FacultyId': $(FacultyDD).val() },
        success: function (data) {

            renderBook($(FacultyDD).parents('.mycontainer').find('select.Book'), data);
        },
        error: function (error) {
            console.log(error)
        }
    })
}

function renderBook(element, data) {
    var $ele = $(element);
    $ele.empty()
    $ele.append($('<option/>').val('0').text('Select'));

    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.BookId).text(val.BookName));
    })
}


$(document).ready(function () {
    // Image Section
    //var formData = new FormData();
    //formData.append('file', $('#imageupload')[0].file[0]);

    //Add Items
    $("#add").click(function () {
        var isAllvalid = true;
        if ($('#BookFaculty').val() == "0") {
            isAllvalid = false;
            $('#BookFaculty').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#BookFaculty').siblings('span.error').css('visibility', 'hidden');
        }

        //product
        if ($('#Book').val() == "0") {
            isAllvalid = false;
            $('#Book').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Book').siblings('span.error').css('visibility', 'hidden');
        }

        //Quantity
        if (!$('#quantity').val().trim() != "" && (parseInt($('#quantity').val()) || 0)) {
            isAllValid = false;
            $('#quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }



        //Unite Price
        if (!$('#rate').val().trim() != "" && (!isNaN($('#rate').val().trim()))) {
            isAllValid = false;
            $('#rate').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#rate').siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllvalid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#BookFaculty').val());
            $('.Book', $newRow).val($('#Book').val());
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');
            $('#BookFaculty, #Book, #quantity, #rate, #add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();

            $('#orderDetailsItems').append($newRow);
            $('#BookFaculty, #Book').val('0');
            $('#quantity, #rate').val('');
            $("#orderItemError").empty();
        }
    });

    // Remove Item
    $('#orderDetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    //place Order
    $('#submit').click(function () {
        var isAllValid = true;
        $('#orderItemError').text('');
        var list = []
        var errorItemCount = 0;

        //item add to list
        $('#orderDetailsItems tbody tr').each(function (index, ele) {
            if ($('select.Book', this).val() == "0" || (parseInt($('.quantity', this).val()) || 0) == 0 || $('.rate', this).val() == "" || isNaN($('.rate', this).val())) {
                errorItemCount++;
                $(this).addClass('error');
            }
            else {
                var orderItem = {
                    BookID: $('select.Book', this).val(),
                    Quantity: parseInt($('.quantity', this).val()),
                    UnitPrice: parseFloat($('.rate', this).val())
                }
                list.push(orderItem);
            }
        })

        //error count and validation
        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " Invalid entry in order item list!!!");
            isAllValid = false;
        }
        //No. of Item check
        if (list.length == 0) {
            $('#orderItemError').text(" At least one entry is required to order an item!!!");
            isAllValid = false;
        }
        //date get
        if ($('#orderDate').val().trim() == '') {
            $('#orderDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        }

        //order submit
        if (isAllValid) {
            var data = {
                OrderDate: $('#orderDate').val().trim(),
                Note: $('#note').val(),
                Image: $('#imageupload').val().trim(),
                Terms: $('#bool').is('.checked'),
                OrderDetails: list
                
            }
            console.log(list)
            $(this).val('Please Wait................')
           
            $.ajax({
                type: "POST",
                url: '/Order/Save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert("Order Placed successfully")
                        list = [];
                        $('#orderDate,#note,#imageupload,#bool').val('');
                        $('#orderDetailsItems').empty();

                        //parsed order 
                        //window.location = '/Order/List';
                    }
                    else {
                        alert('***ERROR***')
                    }
                    $('#submit').val('Save');
                },
                error: function (error) {
                    console.log(error)
                    $('#submit').val('Save');
                }
            })
        }

    });

});

LoadFaculty($('#BookFaculty'));