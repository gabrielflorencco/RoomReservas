DROP SCHEMA IF EXISTS sistema_reservas;
CREATE DATABASE sistema_reservas;
USE sistema_reservas;

CREATE TABLE sala (
    id CHAR(36) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    capacidade INT NOT NULL CHECK (capacidade > 0),
    ativa BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE usuario (
    id CHAR(36) PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE
);

CREATE TABLE reserva (
    id CHAR(36) PRIMARY KEY,
    sala_id CHAR(36) NOT NULL,
    usuario_id CHAR(36) NOT NULL,
    inicio TIMESTAMP NOT NULL,
    fim TIMESTAMP NOT NULL,
    status INT NOT NULL,
    valor_total DOUBLE NOT NULL,
    data_criacao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_reserva_sala
        FOREIGN KEY (sala_id) REFERENCES sala(id),

    CONSTRAINT fk_reserva_usuario
        FOREIGN KEY (usuario_id) REFERENCES usuario(id),

    CONSTRAINT chk_periodo_valido
        CHECK (inicio < fim)
);

CREATE INDEX idx_reserva_sala_periodo
    ON reserva (sala_id, inicio, fim);

CREATE INDEX idx_reserva_usuario
    ON reserva (usuario_id);

SELECT * FROM reserva;