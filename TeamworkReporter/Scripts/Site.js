(function ($) {
    $.fn.timelogRefresh = function(parametrs) {
        var options = $.extend({
            timelogGridClass: "",
            timelogPeopleClass: "",
            timelogPeriodsClass: "",
            urlToGetUpdatedGrid: ""
        }, parametrs);
        this.each(function(index, element) {
            $(element).click(function() {
                // gather selection and post to the server with callback.
                // the callback will refresh the grid
                var $people = $(options.timelogPeopleClass).find("input:checked");
                var period = $(options.timelogPeriodsClass).find("input:checked").val();
                var data = {
                    SelectedPeople: [],
                    Period: period
                };
                for(var idx =0; idx < $people.length; idx++) {
                    var $person = $($people[idx]);
                    data.SelectedPeople.push({
                        Id: $person.val(),
                        FullName: $person.data("fullname")
                    });
                }

                $.post(options.urlToGetUpdatedGrid, $.postify(data))
                    .done(function() {  })
                    .success(function(data) {
                        $(options.timelogGridClass).html(data);
                    })
                    .fail(function () {  })
                    .always(function() { });
            });
        });
    };
}(jQuery));