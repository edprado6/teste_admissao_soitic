/*
 * Os eventos abaixo são disparados quando os botões de Excluir das tabelas de
 * dados são clicados.
 */
$(document).on("click", ".btn-delete-categoria", function (event) {
    event.preventDefault();
    var categoria_id = $(this).data('id');
    $('#excluir-categoria-action').data('categoria_id', categoria_id);
    $('#alertCategoriaModal').modal('show');
});

$(document).on("click", ".btn-delete-autor", function (event) {
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

/*
 * Evento disparado ao clicar em detalhes de autor. Chama a função que faz
 * a requisicão ao servidor passando um autor_id.
 */
$(document).on("click", ".btn-detalhes-autor", function (event) {
    event.preventDefault();
    var autor_id = $(this).data('id'); 
    LoadAutorById(autor_id);
});


/*
 * Evento disparado ao clicar em detalhes de categoria. Chama a função que faz
 * a requisicão ao servidor passando um categoria_id.
 */
$(document).on("click", ".btn-detalhes-categoria", function (event) {
    event.preventDefault();
    var categoria_id = $(this).data('id');
    LoadCategoriaById(categoria_id);
});

/*
 * Evento disparado ao clicar em detalhes de livro. Chama a função que faz
 * a requisicão ao servidor passando um livro_id.
 */
$(document).on("click", ".btn-detalhes-livro", function (event) {
    event.preventDefault();
    var livro_id = $(this).data('id');
    LoadLivroById(livro_id);
});


/*
 * Função que realiza requisição junto ao servidor. Envia um autor_id e recebe
 * um objeto data.
 */
function LoadAutorById(autor_id) {
    $('#modal-body').empty();
    $.getJSON("/autor/detalhes?id=" + autor_id, null, function (data) {
        if (data == "FAILED") {
            $('#modal-body').append("<div><label>Não foi encontrado nenhum autor com o código informado.</b></div>" )
        }
        else {
            var data_insercao = fomateDate(data.DataInsercao);
            var data_alteracao = fomateDate(data.DataAlteracao);
            $('#modal-body').append("<div><label>Cód.: </label><b> " + data.AutorId + "  </b></div>" +
            "<div><label>Autor: </label><b> " + data.NomeAutor + "  </b></div>" +
            "<div><label>Data de inserção: </label><b> " + data_insercao + " </b></div>" +
            "<div><label>Data de alteração: </label><b> " + data_alteracao + " </b></div>"   );
        }

    });
    $('#detalheModal').modal('show');
}


/*
 * Função que realiza requisição junto ao servidor. Envia um categoria_id e recebe
 * um objeto data.
 */
function LoadCategoriaById(categoria_id) {
    $('#modal-body').empty();
    $.getJSON("/categoria/detalhes?id=" + categoria_id, null, function (data) {
        if (data == "FAILED") {
            $('#modal-body').append("<div><label>Não foi encontrada nenhuma categoria com o código informado.</b></div>")
        }
        else {
            var data_insercao = fomateDate(data.DataInsercao);
            var data_alteracao = fomateDate(data.DataAlteracao);
            $('#modal-body').append("<div><label>Cód.: </label><b> " + data.CategoriaId + "  </b></div>" +
            "<div><label>Categoria: </label><b> " + data.NomeCategoria + "  </b></div>" +
            "<div><label>Data de inserção: </label><b> " + data_insercao + " </b></div>" +
            "<div><label>Data de alteração: </label><b> " + data_alteracao + " </b></div>");
        }

    });
    $('#detalheModal').modal('show');
}

/*
 * Função que realiza requisição junto ao servidor. Envia um livro_id e recebe
 * um objeto data.
 */
function LoadLivroById(livro_id) {
    $('#modal-body').empty();
    $.getJSON("/livro/detalhes?id=" + livro_id, null, function (data) {
        if (data == "FAILED") {
            $('#modal-body').append("<div><label>Não foi encontrado nenhum livro com o código informado.</b></div>")
        }
        else {
            var data_insercao = fomateDate(data.DataInsercao);
            var data_alteracao = fomateDate(data.DataAlteracao);
            $('#modal-body').append("<div><label>Cód.: </label><b> " + data.LivroId + "  </b></div>" +
            "<div><label>Livro: </label><b> " + data.NomeLivro + "  </b></div>" +
            "<div><label>Autor: </label><b> " + + "  </b></div>" +
            "<div><label>categoria: </label><b> " +  + "  </b></div>" +
            "<div><label>Ano de publicação: </label><b> " + data.AnoPublicacao + "  </b></div>" +
            "<div><label>Editora: </label><b> " + data.Editora + "  </b></div>" +
            "<div><label>Edição: </label><b> " + data.Edicao + "  </b></div>" +
            "<div><label>Data de inserção: </label><b> " + data_insercao + " </b></div>" +
            "<div><label>Data de alteração: </label><b> " + data_alteracao + " </b></div>");
        }

    });
    $('#detalheModal').modal('show');
}

/*
 * Formata Microsoft Json Date em uma data no formato dd/mm/yyyy.
 */
function fomateDate(dataAFormatar) {
    var dataRetornada = new Date(parseInt(dataAFormatar.substr(6)));
    dataRetornada = dataRetornada.getDate() + "/" + dataRetornada.getMonth() + 1 + "/" + dataRetornada.getFullYear();
    return dataRetornada;
}


$(document).ready(function () {

    /* 
     * As chamadas abaixo direcionam para os métodos das Controllers responsáveis
     * pela exclusão de itens.
     */
    $('#excluir-categoria-action').click(function (event) {
        var categoria_id = $(this).data('categoria_id'); 
        document.location = '../categoria/delete?id=' + categoria_id;        
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