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
            //console.log(resultado)
            $(IdLocalResultado).html(resultado);
        },

        complete: function () {
            // initTooltips();
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
            $.ajax({
                url: form.attr('action'),
                type: 'POST',
                data: form.serialize(),
                headers: {
                    'X-Requested-With': 'XMLHttpRequest'
                },
                beforeSend: function () {
                    $('.btn-deletar').prop('disabled', true);
                },
                complete: function () {
                    $('.btn-deletar').prop('disabled', false);
                }
            })
                .done(function (response) {
                    Swal.fire({
                        icon: 'success',
                        title: response?.title ?? 'Sucesso',
                        html: response?.detail ?? 'Solicitação concluída com sucesso!'
                    }).then(() => {
                        if (response.redirectUrl) {
                            window.location.href = response.redirectUrl;
                        } else {
                            window.location.reload();
                        }
                    });
                })
                .fail(function (xhr) {
                    if (xhr.responseJSON) {
                        Swal.fire({
                            icon: 'error',
                            title: xhr.responseJSON.title ?? 'Erro',
                            html: xhr.responseJSON.detail
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Erro',
                            text: 'Erro inesperado ao processar a requisição.'
                        });
                    }
                });

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
        pesquisar(e, formId, url, "#resultado");
    }
    else {
        submit(e, formId, url);
    }
})


// LOADINGS

window.Loading = (function () {

    const defaultConfigs = {
        "overlayBackgroundColor": "#000000",
        "overlayOpacity": 0.6,
        "spinnerIcon": "fire",
        "spinnerColor": "#FFFFFF",
        "spinnerSize": "2x",
        "overlayIDName": "Carregando",
        "spinnerIDName": "",
        "offsetX": 0,
        "offsetY": 0,
        "containerID": null,
        "lockScroll": true,
        "overlayZIndex": 9998,
        "spinnerZIndex": 9999
    };

    function show(customConfigs = {}) {
        $.LoadingOverlay("show", {
            ...defaultConfigs,
            ...customConfigs
        });
    }

    function hide() {
        $.LoadingOverlay("hide");
    }

    return {
        show,
        hide
    };

})();

$(document).ajaxStart(function () {
    Loading.show();
});

$(document).ajaxStop(function () {
    Loading.hide();
});

$(document).ready(function () {
    carregarMask();
});

function carregarMask() {
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.date_time').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000');
    $('.tel').mask('00000-0000');
    $('.tel_com_ddd').mask('(00) 00000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.money2').mask("#.##0,00", { reverse: true });
    $('.ip_address').mask('0ZZ.0ZZ.0ZZ.0ZZ', {
        translation: {
            'Z': {
                pattern: /[0-9]/, optional: true
            }
        }
    });
    $('.ip_address').mask('099.099.099.099');
    $('.percent').mask('##0,00%', { reverse: true });
    $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
    $('.placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
    $('.fallback').mask("00r00r0000", {
        translation: {
            'r': {
                pattern: /[\/]/,
                fallback: '/'
            },
            placeholder: "__/__/____"
        }
    });
    $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });
}
