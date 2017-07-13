<%--  Code fragment showing an example of invoking Ajax  --%>
<%-- Notice that the parameters from DataTable must be encapsulated in 
     a Javascript object, and then stringified.
    Notice also that the name of the Javascript object ("paerameters" in this example
    has to match the parameter name in the WebMethod, or dotnet won't find the correct
    WebMethod and the Ajax call will kick back a 500 error.
    
    Permission to use this code for any purpose and without fee is hereby granted.
    No warrantles.

--%>

<script type="text/javascript" src="/assets/js/datatables.min.js"></script>
<script type="text/javascript" >
 
  $(document).ready(function () {
    $('#mytable').DataTable({
      processing: true,
      serverSide: true,
      ajax: {
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/DataTables.aspx/Data",
        data: function (d) {
          return JSON.stringify({ parameters: d });
        }
      }
    });
  });
  </script>
