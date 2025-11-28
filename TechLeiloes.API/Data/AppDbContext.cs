using TechLeiloes.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TechLeiloes.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "helooboarettoo@gmail.com",
                NormalizedEmail = "HELOOBOARETTOO@GMAIL.COM",
                UserName = "heloboaretto",
                NormalizedUserName = "HELOBOARETTO",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Heloísa Boaretto",
                DataNascimento = DateTime.Parse("24/07/2008"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
             new Categoria() {
                Id = 1,
                Nome = "Casa",
                Foto = "/img/categorias/casa-limpa.png",
                Cor = "#000"
            },
            new Categoria() {
                Id = 2,
                Nome = "Apartamento",
                Foto = "/img/categorias/apartamento.png",
                Cor = "#000"
            },
                        new Categoria() {
                Id = 3,
                Nome = "Imóvel Comercial",
                Foto = "/img/categorias/loja.png",
                Cor = "#000"
            },
                        new Categoria() {
                Id = 4,
                Nome = "Área Rural",
                Foto = "/img/categorias/terreno.png",
                Cor = "#000"
            },            new Categoria() {
                Id = 5,
                Nome = "Área Industrial",
                Foto = "/img/categorias/industria.png",
                Cor = "#000"
            },new Categoria() {
                Id = 6,
                Nome = "Agência",
                Foto = "/img/categorias/publicidade.png",
                Cor = "#000"
            },
            new Categoria() {
                Id = 7,
                Nome = "Galpão",
                Foto = "/img/categorias/galpao.png",
                Cor = "#000"
            },
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto() {
                Id = 1,
                Nome = "Apto - 173,69m² -3 Vagas -Alto Padrão - Bragança Paulista/SP",
                Descricao = " Lance mínimo atual: R$ 594.106,49",
                CategoriaId = 2,
                Foto = "/img/Produtos/imagem1.jpg",
                ValorVenda=594106,
                Destaque = true,
              
            },
            new Produto() {
                Id = 2,
                Nome = "Direitos - Apartamento c/ 50,42m² - Vaga - Sertãozinho/SP",
                Descricao = "Lance mínimo atual: R$ 41.248,36 ",
                CategoriaId = 2,
                Foto = "/img/Produtos/imagem2.jpg",
                ValorVenda = 41248,
                Destaque = true,
            },
            new Produto() {
                Id = 3,
                Nome = "Edificação c/ 132,25m² - Terreno c/ 250m² - São Paulo/SP Air",
                Descricao = " Lance mínimo atual: R$ 501.304,06",
                CategoriaId = 1,
                Foto = "/img/Produtos/imagem3.jpg",
                ValorVenda=501304,
                Destaque = true,
            },
            new Produto() {
                Id = 4,
                Nome = "Casa Alto Padrão 561,70m² - Terreno - 1.400m² - Barueri/SP",
                Descricao = " Lance mínimo atual: R$ 2.568.229,28",
                CategoriaId = 1,
                Foto = "/img/Produtos/imagem4.jpg",
                ValorVenda = 2568229,
                Destaque = true,
            },
            new Produto() {
                Id = 5,
                Nome = "Parte (6%) de Thermas Parque Hotel -Conceição das Alagoas/MG",
                Descricao = " Lance mínimo atual: R$ 1.674.648,04",
                CategoriaId = 2,
                Foto = "/img/Produtos/imagem5.jpg",
                Destaque = true,
                ValorVenda=1674648,
            },
            new Produto() {
                Id = 6,
                Nome = "Direitos - Apartamento - 46,63m² - 02 Dorms. - Bauru/SP",
                Descricao = "Lance mínimo atual: R$ 131.582,46 ",
                CategoriaId = 2,
                Foto = "/img/Produtos/imagem6.jpg",
                ValorVenda = 131582,
                Destaque = true,
            },
            new Produto() {
                Id = 7,
                Nome = "Chácara c/ 4,2609 hectares - Rosana/SP",
                Descricao = "Lance mínimo atual: R$ 641.712,00 ",
                CategoriaId = 1,
                Foto = "/img/Produtos/imagem7.jpg",
                ValorVenda = 641712,
                Destaque = true,
            },
            new Produto() {
                Id = 8,
                Nome = "Grande Imóvel Comercial - 2.583,00ms² - Campos do Jordão/SP",
                Descricao = "Lance mínimo atual: R$ 4.179.000,00 ",
                CategoriaId = 1,
                ValorVenda = 4179000,
                Foto = "/img/Produtos/imagem8.jpg",
                Destaque = true,
            },
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}