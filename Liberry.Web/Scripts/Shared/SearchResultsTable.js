(function () {

    function SearchResultsTable(containerId) {
        this.$container = $("#" + containerId);
        this.table = null;
    }

    SearchResultsTable.prototype.showResults = function (json) {
        if (this.table) this.table.remove();
        this.table = document.createElement("table");
        this.table.classList.add("table");

        var properties = Object.keys(json[0]); // TODO: What to do if no results?

        // thead
        var thead = document.createElement("thead");
        var thead_tr = document.createElement("tr");
        for (var i = 0; i < properties.length; i++) {
            var th = document.createElement("th");
            th.innerText = properties[i];
            thead_tr.appendChild(th);
        }
        thead.appendChild(thead_tr);
        this.table.appendChild(thead);

        // tbody
        var tbody = document.createElement("tbody");
        for (i = 0; i < json.length; i++) {
            var tr = document.createElement("tr");

            for (var j = 0; j < properties.length; j++) {
                var td = document.createElement("td");
                td.innerText = json[i][properties[j]];
                tr.appendChild(td);
            }

            tbody.appendChild(tr);
        }
        this.table.appendChild(tbody);

        $(this.table).appendTo(this.$container);
    };

    window.SearchResultsTable = SearchResultsTable;

})();