﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desafio_Mantis.Queries {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TarefasQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TarefasQueries() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Desafio_Mantis.Queries.TarefasQueries", typeof(TarefasQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a DELETE FROM mantis_bug_history_table WHERE EXISTS (SELECT * FROM  mantis_bug_text_table WHERE mantis_bug_history_table.bug_id=mantis_bug_text_table.id AND  mantis_bug_text_table.description=&apos;$descricaoTarefa&apos;); DELETE  FROM  mantis_bug_table WHERE EXISTS (SELECT * FROM  mantis_bug_text_table WHERE mantis_bug_table.bug_text_id=mantis_bug_text_table.id AND  mantis_bug_text_table.description=&apos;$descricaoTarefa&apos; AND summary=&apos;$resumoTarefa&apos;);DELETE  FROM  mantis_bug_text_table WHERE description=&apos;$descricaoTarefa&apos; [o restante da cadeia de caracteres foi truncado]&quot;;.
        /// </summary>
        internal static string DeletaTarefa {
            get {
                return ResourceManager.GetString("DeletaTarefa", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(*)  FROM mantis_bug_table mbt
        ///iNNER JOIN mantis_bug_text_table mbtt
        ///ON mbt.bug_text_id=mbtt.id
        ///WHERE mbt.summary=&apos;$resumoTarefa&apos; AND 
        ///mbtt.description=&apos;$descricaoTarefa&apos;;.
        /// </summary>
        internal static string RetornaTarefa {
            get {
                return ResourceManager.GetString("RetornaTarefa", resourceCulture);
            }
        }
    }
}
