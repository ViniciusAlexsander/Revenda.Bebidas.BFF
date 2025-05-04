CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE revendas (
    id UUID PRIMARY KEY,
    cnpj VARCHAR(18) NOT NULL,
    razao_social  VARCHAR(255) NOT NULL,
    nome_fantasia  VARCHAR(255),
    email VARCHAR(255),
    telefone VARCHAR(20),
    nome_contato VARCHAR(255),
    endereco_entrega VARCHAR(255),
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    atualizado_em TIMESTAMP NOT NULL DEFAULT NOW()
);

CREATE TABLE produtos (
    id UUID PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    descricao TEXT,
    preco NUMERIC(10, 2) NOT NULL,
    unidade VARCHAR(50) NOT NULL
);

CREATE TABLE pedidos (
    id UUID PRIMARY KEY,
    cliente_id UUID REFERENCES clientes(id) ON DELETE CASCADE,
    revenda_id UUID REFERENCES revendas(id) ON DELETE CASCADE,
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(50) DEFAULT 'pendente'
);

CREATE TABLE itens_pedido (
    id UUID PRIMARY KEY,
    pedido_id UUID NOT NULL REFERENCES pedidos(id) ON DELETE CASCADE,
    produto_id UUID NOT NULL REFERENCES produtos(id),
    quantidade INT NOT NULL CHECK (quantidade > 0)
);

CREATE TABLE clientes (
    id UUID PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255),
    telefone VARCHAR(20),
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE PedidosFabrica (
    id UUID PRIMARY KEY,
    revenda_id UUID NOT NULL,
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status VARCHAR(20) NOT NULL, --"Pendente", "Processando", "Enviado", "Erro"
    tentativas_envio INT NOT NULL DEFAULT 0,
    atualizado_em TIMESTAMP NOT NULL DEFAULT NOW(),
    mensagem_erro VARCHAR NULL
);

CREATE TABLE pedidos_fabrica_para_pedidos_cliente (
    id UUID PRIMARY KEY,
    pedido_fabrica_id UUID NOT NULL REFERENCES pedidosfabrica(id),
    pedido_cliente_id UUID NOT NULL REFERENCES pedidos(id)
);

INSERT INTO produtos (id, nome, descricao, preco, unidade)
VALUES (uuid_generate_v4(), 'Cerveja Pilsen 600ml', 'Cerveja clara', 5.99, 'UN');

INSERT INTO produtos (id, nome, descricao, preco, unidade)
VALUES (uuid_generate_v4(), 'Guaraná', 'Refrigerante de guaraná', 4.50, 'UN');