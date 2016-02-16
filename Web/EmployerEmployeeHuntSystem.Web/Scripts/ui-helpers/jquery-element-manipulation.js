var jqueryElementManipulation = (function () {
    function toggleClassOfTableRow(dataActionName, className) {
        $('button[data-action="' + dataActionName + '"]').on('click', function (ev) {
            var $this,
                $currentRow,
                rowId;

            $this = $(this);
            rowId = $this.attr('data-id');
            $currentRow = $('tr[data-id="' + rowId + '"]');

            if ($currentRow.hasClass(className)) {
                $currentRow.removeClass(className);
            }
            else {
                $currentRow.addClass(className);
            }
        });
    }

    return {
        toggleClassOfTableRow: toggleClassOfTableRow
    };
}());