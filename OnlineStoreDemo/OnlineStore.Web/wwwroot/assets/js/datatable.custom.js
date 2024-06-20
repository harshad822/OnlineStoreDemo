(function ($) {
    $(document).ready(function () {
        $("#bd-matching").DataTable({
            responsive: true,
            scrollY: "42vh",
            scrollCollapse: true,
            paging: false,
            ordering: false,
            searching: false,
            stripeClasses: [],
            info: false,
        });

        $("#latest-ratings").DataTable({
            responsive: true,
            scrollY: "42vh",
            scrollCollapse: true,
            paging: false,
            ordering: false,
            searching: false,
            stripeClasses: [],
            info: false,
        });

        $("#ets").DataTable({
            responsive: true,
            scrollY: "40vh",
            scrollCollapse: true,
            paging: false,
            ordering: false,
            searching: false,
            stripeClasses: [],
            info: false,
        });

        $("#activeJobPost").DataTable({
            responsive: true,
            scrollY: "40vh",
            scrollCollapse: true,
            paging: false,
            ordering: false,
            searching: false,
            stripeClasses: [],
            info: false,
            columnDefs: [
                { width: "60%", targets: 0 },
                { width: "40%", targets: 1 },
            ],
        });

        $("#transtbl").DataTable({
            //responsive: true,
            //scrollY: "40vh",
            scrollCollapse: true,
            paging: false,
            ordering: false,
            searching: false,
            stripeClasses: [],
            info: false,
        });

        $("#transaction-escrow").DataTable({
            responsive: true,
            ordering: false,
            scrollCollapse: true,
            stripeClasses: [],
            info: false,
        });
        $("#TeamInvitaionTbl").DataTable({
            responsive: true,
            ordering: false,
            scrollCollapse: true,
            stripeClasses: [],
            info: false,
            paging: false,
            ordering: false,
            searching: false,
        });
        $("#opp-bd-matching").DataTable({
            responsive: true,
            scrollY: "67vh",
            scrollCollapse: true,
            paging: false,
            ordering: false,
            searching: false,
            stripeClasses: [],
            info: false,
        });

    $("#campaigns").DataTable({
      responsive: true,
      scrollY: "67vh",
      scrollCollapse: true,
      paging: false,
      ordering: false,
      searching: false,
      stripeClasses: [],
      info: false,
    });

    $("#admin-verify-profile").DataTable({
      responsive: true,
      ordering: false,
      scrollCollapse: true,
      stripeClasses: [],
      info: false,
    });

    $("#admin-delete-profile").DataTable({
      responsive: true,
      ordering: false,
      scrollCollapse: true,
      stripeClasses: [],
      info: false,
    });

    //datatable dom ordering end here
  });
})(jQuery);
