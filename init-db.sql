-- Script de inicialização do banco de dados
-- Cria extensões necessárias
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";
CREATE EXTENSION IF NOT EXISTS "pg_trgm";

-- Confirma que o banco e o usuário foram criados corretamente
\c financial_control

-- Comentário informativo
-- Banco de dados 'financial_control' criado com sucesso!
-- Tabelas serão criadas automaticamente pelo Entity Framework

