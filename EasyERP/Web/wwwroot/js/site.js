function pesquisar(evt, IdDoFormulario, UrlPesquisa, IdLocalResultado) {
    evt.preventDefault();
    $.ajax({
        type: "POST",
        url: UrlPesquisa,
        dataType: 'html',
        data: $(IdDoFormulario).serialize(),

        beforeSend: function () {
        },

        success: function (resultado) {
            $(IdLocalResultado).html(resultado);
        },

        complete: function () {
            initTooltips();
        },

        error: function () {
        }
    });
}

function submit(evt, formID, urlSubmit, btnSelector = '#btnSalvar') {
    evt.preventDefault()
    const form = document.getElementById(formID);
    const formData = new FormData(form);

    return $.ajax({
        url: urlSubmit,
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        headers: {
            'X-Requested-With': 'XMLHttpRequest'
        },
        beforeSend: function () {
            $(btnSelector).prop('disabled', true);
        },
        complete: function () {
            $(btnSelector).prop('disabled', false);
        }
    })
        .done(function (response) {

            if (!response?.success) {
                Swal.fire({
                    icon: 'error',
                    title: response?.title ?? 'Erro',
                    html: response?.detail ?? 'Erro ao processar a solicitação.'
                });
                return;
            }

            Swal.fire({
                icon: 'success',
                title: response?.title ?? 'Sucesso',
                html: response?.detail ?? 'Solicitação concluída com sucesso!'
            }).then(() => {

                if (response.pergunta) {

                    Swal.fire({
                        title: 'Solicitação concluída com sucesso. Deseja permanecer nesta página?',
                        icon: 'question',
                        showDenyButton: true,
                        confirmButtonText: 'Sim',
                        denyButtonText: 'Não'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            window.location.reload();
                            return;
                        }
                        if (result.isDenied) {
                            if (response.redirectUrl) {
                                window.location.href = response.redirectUrl;
                                return;
                            }
                        }
                    });

                    return;
                }

                if (response.redirectUrl) {
                    window.location.href = response.redirectUrl;
                    return;
                }

                if (response.reloadPage) {
                    window.location.reload();
                }
            });
        })
        .fail(function (xhr) {

            const json = xhr.responseJSON;

            Swal.fire({
                icon: 'error',
                title: json?.title ?? 'Erro',
                html: json?.detail ?? 'Erro inesperado ao processar a requisição.'
            });
        });
}

$(document).on('click', '.btn-editar', function (e) {
    e.preventDefault();
    const rota = $(this).data("rota-edicao");
    window.location.href = rota;
})

$(document).on('click', '.btn-deletar', function (e) {
    e.preventDefault();

    const form = $(this).closest("form");

    Swal.fire({
        title: "Realmente deseja deletar este registro?",
        showDenyButton: true,
        denyButtonText: "Não",
        confirmButtonText: "Sim",
    }).then((result) => {
        if (result.isConfirmed) {
            form.trigger("submit");
        }
    })
})

$(document).on('submit', 'form[data-ajax="true"]', function (e)
{
    e.preventDefault();
    const form = this;

    const url = form.action;
    const formId = form.id;
    const method = form.method;
    const data = $(form).serialize();

    const success = $(form).data('success');
    const error = $(form).data('error');

    // console.log(url)
    // console.log(formId)
    // console.log(method)
    // console.log(data)

    if (formId.includes('pesquisa')) {
        pesquisar(e, formId, url, "resultado");
    }
    else {
        submit(e, formId, url);
    }
})