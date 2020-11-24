using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LanchesMac.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Endereco { get; set; }
        public string Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //link
            output.Attributes.SetAttribute("href", $"mailto:{Endereco}"); //chamar o envio de email default
            output.Content.SetContent(Conteudo);//mensagem que irá aparecer na tela ex: "clique aqui para enviar um e-mail"
        }
    }
}