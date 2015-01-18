$(document).on("click", "#btn-delete-categoria", function (event) {
    event.preventDefault();
    var categoria_id = $(this).data('id');
    $('#excluir-categoria-action').data('categoria_id', categoria_id);
    $('#alertCategoriaModal').modal('show');
});

$(document).on("click", "#btn-delete-autor", function (event) {
    event.preventDefault();
    var autor_id = $(this).data('id');
    $('#excluir-autor-action').data('autor_id', autor_id);
    $('#alertAutorModal').modal('show');
});

$(document).on("click", ".btn-delete-livro", function (event) {
    event.preventDefault();
    var livro_id = $(this).data('id');
    $('#excluir-livro-action').data('livro_id', livro_id);
    $('#alertLivroModal').modal('show');
});

$(document).ready(function () {

    /* 
     * As chamadas abaixo direcionam para os métodos das Controllers responsáveis
     * pela exclusão de itens.
     */
    $('#excluir-categoria-action').click(function (event) {
        var categoria_id = $(this).data('categoria_id'); 
        document.location = '../categoria/delete?id=' + categoria_id;
        //window.location.href = '../Categoria/Delete/' + categoria_id;
    });

    $('#excluir-autor-action').click(function (event) {
        var autor_id = $(this).data('autor_id');
        document.location = '../autor/delete?id=' + autor_id;        
    });

    $('#excluir-livro-action').click(function (event) {
        var livro_id = $(this).data('livro_id');
        document.location = '../livro/delete?id=' + livro_id;
    });
    
    /*
     * As chamadas abaixo atribuem características como: paginação, pesquisa e
     * ordenação às tabelas de conteúdo.
     */
    $('#dataTables-categoria').DataTable({
        responsive: true
    });

    $('#dataTables-autor').DataTable({
        responsive: true
    });

    $('#dataTables-livro').DataTable({
        responsive: true
    });

});