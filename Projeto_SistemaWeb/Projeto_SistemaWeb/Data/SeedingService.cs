﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_SistemaWeb.Models;
using Projeto_SistemaWeb.Models.Enums;
namespace Projeto_SistemaWeb.Data
{
    public class SeedingService
    {
        private Projeto_SistemaWebContext _context;

        public SeedingService(Projeto_SistemaWebContext context)
        {
            _context = context;
        }

        public void Seed() // classe pra popular o banco de dados manual
        {
            if(_context.Department.Any() || _context.Seller.Any() || _context.RegistroDeVendas.Any())
            {
                return; // Banco de dados ja foi populado.
            }

            Department d1 = new Department(1, "Computadores e Informática");
            Department d2 = new Department(2, "Eletrônicos, TV e Áudio");
            Department d3 = new Department(3, "Livros");
            Department d4 = new Department(4, "Celulares e Comunicação");

            Seller s1 = new Seller(1, "Bob Brow", "BOB.@gmail.com", new DateTime(1998, 4, 21), 1000.00, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new Seller(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            RegistroDeVenda r1 = new RegistroDeVenda(1, new DateTime(2018, 09, 25), 11000.00, StatusVenda.Faturado, s1);
            RegistroDeVenda r2 = new RegistroDeVenda(2, new DateTime(2018, 09, 4), 7000.0, StatusVenda.Faturado, s5);
            RegistroDeVenda r3 = new RegistroDeVenda(3, new DateTime(2018, 09, 13), 4000.0, StatusVenda.Cancelado, s4);
            RegistroDeVenda r4 = new RegistroDeVenda(4, new DateTime(2018, 09, 1), 8000.0, StatusVenda.Faturado, s1);
            RegistroDeVenda r5 = new RegistroDeVenda(5, new DateTime(2018, 09, 21), 3000.0, StatusVenda.Faturado, s3);
            RegistroDeVenda r6 = new RegistroDeVenda(6, new DateTime(2018, 09, 15), 2000.0, StatusVenda.Faturado, s1);
            RegistroDeVenda r7 = new RegistroDeVenda(7, new DateTime(2018, 09, 28), 13000.0, StatusVenda.Faturado, s2);
            RegistroDeVenda r8 = new RegistroDeVenda(8, new DateTime(2018, 09, 11), 4000.0, StatusVenda.Faturado, s4);
            RegistroDeVenda r9 = new RegistroDeVenda(9, new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, s6);
            RegistroDeVenda r10 = new RegistroDeVenda(10, new DateTime(2018, 09, 7), 9000.0, StatusVenda.Faturado, s6);
            RegistroDeVenda r11 = new RegistroDeVenda(11, new DateTime(2018, 09, 13), 6000.0, StatusVenda.Faturado, s2);
            RegistroDeVenda r12 = new RegistroDeVenda(12, new DateTime(2018, 09, 25), 7000.0, StatusVenda.Pendente, s3);
            RegistroDeVenda r13 = new RegistroDeVenda(13, new DateTime(2018, 09, 29), 10000.0, StatusVenda.Faturado, s4);
            RegistroDeVenda r14 = new RegistroDeVenda(14, new DateTime(2018, 09, 4), 3000.0, StatusVenda.Faturado, s5);
            RegistroDeVenda r15 = new RegistroDeVenda(15, new DateTime(2018, 09, 12), 4000.0, StatusVenda.Faturado, s1);
            RegistroDeVenda r16 = new RegistroDeVenda(16, new DateTime(2018, 10, 5), 2000.0, StatusVenda.Faturado, s4);
            RegistroDeVenda r17 = new RegistroDeVenda(17, new DateTime(2018, 10, 1), 12000.0, StatusVenda.Faturado, s1);
            RegistroDeVenda r18 = new RegistroDeVenda(18, new DateTime(2018, 10, 24), 6000.0, StatusVenda.Faturado, s3);
            RegistroDeVenda r19 = new RegistroDeVenda(19, new DateTime(2018, 10, 22), 8000.0, StatusVenda.Faturado, s5);
            RegistroDeVenda r20 = new RegistroDeVenda(20, new DateTime(2018, 10, 15), 8000.0, StatusVenda.Faturado, s6);
            RegistroDeVenda r21 = new RegistroDeVenda(21, new DateTime(2018, 10, 17), 9000.0, StatusVenda.Faturado, s2);
            RegistroDeVenda r22 = new RegistroDeVenda(22, new DateTime(2018, 10, 24), 4000.0, StatusVenda.Faturado, s4);
            RegistroDeVenda r23 = new RegistroDeVenda(23, new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, s2);
            RegistroDeVenda r24 = new RegistroDeVenda(24, new DateTime(2018, 10, 12), 8000.0, StatusVenda.Faturado, s5);
            RegistroDeVenda r25 = new RegistroDeVenda(25, new DateTime(2018, 10, 31), 7000.0, StatusVenda.Faturado, s3);
            RegistroDeVenda r26 = new RegistroDeVenda(26, new DateTime(2018, 10, 6), 5000.0, StatusVenda.Faturado, s4);
            RegistroDeVenda r27 = new RegistroDeVenda(27, new DateTime(2018, 10, 13), 9000.0, StatusVenda.Pendente, s1);
            RegistroDeVenda r28 = new RegistroDeVenda(28, new DateTime(2018, 10, 7), 4000.0, StatusVenda.Faturado, s3);
            RegistroDeVenda r29 = new RegistroDeVenda(29, new DateTime(2018, 10, 23), 12000.0, StatusVenda.Faturado, s5);
            RegistroDeVenda r30 = new RegistroDeVenda(30, new DateTime(2018, 10, 12), 5000.0, StatusVenda.Faturado, s2);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.RegistroDeVendas.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
                );

            _context.SaveChanges(); // salva e confirma todos os dados e alteraçoes no banco de dados

        }
    }
}
