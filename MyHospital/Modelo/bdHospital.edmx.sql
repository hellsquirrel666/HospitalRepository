
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/30/2016 22:16:06
-- Generated from EDMX file: C:\Users\Lau2\Desktop\GitHub\HospitalRepository\MyHospital\Modelo\bdHospital.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Agenda_Pacientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agenda] DROP CONSTRAINT [FK_Agenda_Pacientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Agenda_USUARIOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Agenda] DROP CONSTRAINT [FK_Agenda_USUARIOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Colonias_Municipios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Colonias] DROP CONSTRAINT [FK_Colonias_Municipios];
GO
IF OBJECT_ID(N'[dbo].[FK_Consulta_Pacientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Consulta] DROP CONSTRAINT [FK_Consulta_Pacientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Consulta_USUARIOS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Consulta] DROP CONSTRAINT [FK_Consulta_USUARIOS];
GO
IF OBJECT_ID(N'[dbo].[FK_Cuidades_Estados]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuidades] DROP CONSTRAINT [FK_Cuidades_Estados];
GO
IF OBJECT_ID(N'[dbo].[FK_Direccion_Colonias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Direccion] DROP CONSTRAINT [FK_Direccion_Colonias];
GO
IF OBJECT_ID(N'[dbo].[FK_Estados_Paises]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Estados] DROP CONSTRAINT [FK_Estados_Paises];
GO
IF OBJECT_ID(N'[dbo].[FK_HitorialClinico_CamposHistClin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HitorialClinico] DROP CONSTRAINT [FK_HitorialClinico_CamposHistClin];
GO
IF OBJECT_ID(N'[dbo].[FK_HitorialClinico_Pacientes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HitorialClinico] DROP CONSTRAINT [FK_HitorialClinico_Pacientes];
GO
IF OBJECT_ID(N'[dbo].[FK_Hospitales_Direccion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Hospitales] DROP CONSTRAINT [FK_Hospitales_Direccion];
GO
IF OBJECT_ID(N'[dbo].[FK_Municipios_Cuidades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Municipios] DROP CONSTRAINT [FK_Municipios_Cuidades];
GO
IF OBJECT_ID(N'[dbo].[FK_Pacientes_GposSanguineos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacientes] DROP CONSTRAINT [FK_Pacientes_GposSanguineos];
GO
IF OBJECT_ID(N'[dbHospitalModelStoreContainer].[FK_Recetas_Consulta]', 'F') IS NOT NULL
    ALTER TABLE [dbHospitalModelStoreContainer].[Recetas] DROP CONSTRAINT [FK_Recetas_Consulta];
GO
IF OBJECT_ID(N'[dbHospitalModelStoreContainer].[FK_Recetas_Medicamentos]', 'F') IS NOT NULL
    ALTER TABLE [dbHospitalModelStoreContainer].[Recetas] DROP CONSTRAINT [FK_Recetas_Medicamentos];
GO
IF OBJECT_ID(N'[dbo].[FK_USUARIOS_Hospitales]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[USUARIOS] DROP CONSTRAINT [FK_USUARIOS_Hospitales];
GO
IF OBJECT_ID(N'[dbo].[FK_USUARIOS_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[USUARIOS] DROP CONSTRAINT [FK_USUARIOS_Roles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Agenda]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Agenda];
GO
IF OBJECT_ID(N'[dbo].[CamposHistClin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CamposHistClin];
GO
IF OBJECT_ID(N'[dbo].[Colonias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Colonias];
GO
IF OBJECT_ID(N'[dbo].[Consulta]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Consulta];
GO
IF OBJECT_ID(N'[dbo].[Cuidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuidades];
GO
IF OBJECT_ID(N'[dbo].[Direccion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Direccion];
GO
IF OBJECT_ID(N'[dbo].[Estados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estados];
GO
IF OBJECT_ID(N'[dbo].[GposSanguineos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GposSanguineos];
GO
IF OBJECT_ID(N'[dbo].[HitorialClinico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HitorialClinico];
GO
IF OBJECT_ID(N'[dbo].[Hospitales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Hospitales];
GO
IF OBJECT_ID(N'[dbo].[Medicamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicamentos];
GO
IF OBJECT_ID(N'[dbo].[Municipios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Municipios];
GO
IF OBJECT_ID(N'[dbo].[Pacientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacientes];
GO
IF OBJECT_ID(N'[dbo].[Paises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paises];
GO
IF OBJECT_ID(N'[dbHospitalModelStoreContainer].[Recetas]', 'U') IS NOT NULL
    DROP TABLE [dbHospitalModelStoreContainer].[Recetas];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[USUARIOS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[USUARIOS];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Agenda'
CREATE TABLE [dbo].[Agenda] (
    [nIdAgenda] int IDENTITY(1,1) NOT NULL,
    [nIdPaciente] int  NOT NULL,
    [nIdUsuario] int  NOT NULL,
    [dFecha] datetime  NOT NULL,
    [bActivo] bit  NOT NULL
);
GO

-- Creating table 'CamposHistClin'
CREATE TABLE [dbo].[CamposHistClin] (
    [nIdCampoHistClin] int IDENTITY(1,1) NOT NULL,
    [sDescripcion] nchar(100)  NOT NULL,
    [bActivo] bit  NOT NULL
);
GO

-- Creating table 'Colonias'
CREATE TABLE [dbo].[Colonias] (
    [nIdColonia] int IDENTITY(1,1) NOT NULL,
    [sColonia] nchar(100)  NOT NULL,
    [sCP] nchar(10)  NOT NULL,
    [nIdMunicipio] int  NOT NULL
);
GO

-- Creating table 'Consulta'
CREATE TABLE [dbo].[Consulta] (
    [nIdConsulta] int IDENTITY(1,1) NOT NULL,
    [nIdPaciente] int  NOT NULL,
    [nIdUsuario] int  NULL,
    [sObservaciones] nchar(3000)  NULL
);
GO

-- Creating table 'Cuidades'
CREATE TABLE [dbo].[Cuidades] (
    [nIdCuidad] int IDENTITY(1,1) NOT NULL,
    [sCuidad] nchar(100)  NOT NULL,
    [nIdEstado] int  NOT NULL
);
GO

-- Creating table 'Direccion'
CREATE TABLE [dbo].[Direccion] (
    [nIdDireccion] int IDENTITY(1,1) NOT NULL,
    [sCalle] nchar(10)  NOT NULL,
    [sNoInterno] nchar(10)  NOT NULL,
    [sNoExterno] nchar(10)  NULL,
    [nIdColonia] int  NOT NULL
);
GO

-- Creating table 'Estados'
CREATE TABLE [dbo].[Estados] (
    [nIdEstado] int IDENTITY(1,1) NOT NULL,
    [sEstado] nvarchar(100)  NOT NULL,
    [nIdPais] int  NOT NULL
);
GO

-- Creating table 'GposSanguineos'
CREATE TABLE [dbo].[GposSanguineos] (
    [nIdGpoSanguineo] int IDENTITY(1,1) NOT NULL,
    [sDescripcion] nchar(30)  NOT NULL,
    [bActivo] bit  NOT NULL
);
GO

-- Creating table 'HitorialClinico'
CREATE TABLE [dbo].[HitorialClinico] (
    [nIdHistorial] int IDENTITY(1,1) NOT NULL,
    [nIdPaciente] int  NOT NULL,
    [nIdCampoHistClin] int  NOT NULL,
    [sObservaciones] nchar(500)  NULL
);
GO

-- Creating table 'Hospitales'
CREATE TABLE [dbo].[Hospitales] (
    [nIdHospital] int IDENTITY(1,1) NOT NULL,
    [sNombre] nchar(200)  NOT NULL,
    [sLogo] nchar(100)  NULL,
    [sTel1] nchar(20)  NOT NULL,
    [sTel2] nchar(20)  NULL,
    [sEmail] nchar(50)  NULL,
    [nIdDireccion] int  NOT NULL,
    [bActivo] bit  NOT NULL
);
GO

-- Creating table 'Medicamentos'
CREATE TABLE [dbo].[Medicamentos] (
    [nIdMedicamento] int IDENTITY(1,1) NOT NULL,
    [sNombre] nchar(200)  NOT NULL,
    [sLaboratorio] nchar(100)  NOT NULL,
    [bCompartido] bit  NOT NULL,
    [sComposicion] nvarchar(max)  NULL,
    [sPosologia] nvarchar(max)  NULL,
    [sIndicaciones] nvarchar(max)  NULL,
    [sContraindicaciones] nvarchar(max)  NULL
);
GO

-- Creating table 'Municipios'
CREATE TABLE [dbo].[Municipios] (
    [nIdMunicipio] int IDENTITY(1,1) NOT NULL,
    [sMunicipio] nchar(100)  NOT NULL,
    [nIdCuidad] int  NOT NULL
);
GO

-- Creating table 'Pacientes'
CREATE TABLE [dbo].[Pacientes] (
    [nIdPaciente] int IDENTITY(1,1) NOT NULL,
    [sNombre] nchar(100)  NOT NULL,
    [sPrimerApellido] nchar(60)  NOT NULL,
    [sSegundoApellido] nchar(60)  NULL,
    [dFechaNac] datetime  NOT NULL,
    [sSexo] nchar(1)  NULL,
    [nIdGpoSanguineo] int  NOT NULL,
    [sNSS] nchar(20)  NULL,
    [sTelefono] nchar(20)  NOT NULL,
    [sCelular] nchar(20)  NULL,
    [sEmail] nchar(100)  NULL,
    [bActivo] bit  NOT NULL
);
GO

-- Creating table 'Paises'
CREATE TABLE [dbo].[Paises] (
    [nIdPais] int IDENTITY(1,1) NOT NULL,
    [sPais] nchar(100)  NOT NULL
);
GO

-- Creating table 'Recetas'
CREATE TABLE [dbo].[Recetas] (
    [nIdreceta] int IDENTITY(1,1) NOT NULL,
    [nIdMedicamento] int  NOT NULL,
    [sObservaciones] nchar(3000)  NULL,
    [bActivo] bit  NOT NULL,
    [nIdConsulta] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [nIdRol] int IDENTITY(1,1) NOT NULL,
    [sDescripcion] nchar(100)  NOT NULL,
    [bActivo] bit  NOT NULL
);
GO

-- Creating table 'USUARIOS'
CREATE TABLE [dbo].[USUARIOS] (
    [nIdUsuario] int IDENTITY(1,1) NOT NULL,
    [sNombre] nchar(100)  NOT NULL,
    [sPrimerApellido] nchar(60)  NOT NULL,
    [sSegundoApellido] nchar(60)  NULL,
    [nIdRol] int  NOT NULL,
    [sImagen] nchar(100)  NULL,
    [sUsuario] nchar(20)  NOT NULL,
    [sContraseña] nchar(20)  NOT NULL,
    [nIdHospital] int  NOT NULL,
    [bActivo] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [nIdAgenda] in table 'Agenda'
ALTER TABLE [dbo].[Agenda]
ADD CONSTRAINT [PK_Agenda]
    PRIMARY KEY CLUSTERED ([nIdAgenda] ASC);
GO

-- Creating primary key on [nIdCampoHistClin] in table 'CamposHistClin'
ALTER TABLE [dbo].[CamposHistClin]
ADD CONSTRAINT [PK_CamposHistClin]
    PRIMARY KEY CLUSTERED ([nIdCampoHistClin] ASC);
GO

-- Creating primary key on [nIdColonia] in table 'Colonias'
ALTER TABLE [dbo].[Colonias]
ADD CONSTRAINT [PK_Colonias]
    PRIMARY KEY CLUSTERED ([nIdColonia] ASC);
GO

-- Creating primary key on [nIdConsulta] in table 'Consulta'
ALTER TABLE [dbo].[Consulta]
ADD CONSTRAINT [PK_Consulta]
    PRIMARY KEY CLUSTERED ([nIdConsulta] ASC);
GO

-- Creating primary key on [nIdCuidad] in table 'Cuidades'
ALTER TABLE [dbo].[Cuidades]
ADD CONSTRAINT [PK_Cuidades]
    PRIMARY KEY CLUSTERED ([nIdCuidad] ASC);
GO

-- Creating primary key on [nIdDireccion] in table 'Direccion'
ALTER TABLE [dbo].[Direccion]
ADD CONSTRAINT [PK_Direccion]
    PRIMARY KEY CLUSTERED ([nIdDireccion] ASC);
GO

-- Creating primary key on [nIdEstado] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [PK_Estados]
    PRIMARY KEY CLUSTERED ([nIdEstado] ASC);
GO

-- Creating primary key on [nIdGpoSanguineo] in table 'GposSanguineos'
ALTER TABLE [dbo].[GposSanguineos]
ADD CONSTRAINT [PK_GposSanguineos]
    PRIMARY KEY CLUSTERED ([nIdGpoSanguineo] ASC);
GO

-- Creating primary key on [nIdHistorial] in table 'HitorialClinico'
ALTER TABLE [dbo].[HitorialClinico]
ADD CONSTRAINT [PK_HitorialClinico]
    PRIMARY KEY CLUSTERED ([nIdHistorial] ASC);
GO

-- Creating primary key on [nIdHospital] in table 'Hospitales'
ALTER TABLE [dbo].[Hospitales]
ADD CONSTRAINT [PK_Hospitales]
    PRIMARY KEY CLUSTERED ([nIdHospital] ASC);
GO

-- Creating primary key on [nIdMedicamento] in table 'Medicamentos'
ALTER TABLE [dbo].[Medicamentos]
ADD CONSTRAINT [PK_Medicamentos]
    PRIMARY KEY CLUSTERED ([nIdMedicamento] ASC);
GO

-- Creating primary key on [nIdMunicipio] in table 'Municipios'
ALTER TABLE [dbo].[Municipios]
ADD CONSTRAINT [PK_Municipios]
    PRIMARY KEY CLUSTERED ([nIdMunicipio] ASC);
GO

-- Creating primary key on [nIdPaciente] in table 'Pacientes'
ALTER TABLE [dbo].[Pacientes]
ADD CONSTRAINT [PK_Pacientes]
    PRIMARY KEY CLUSTERED ([nIdPaciente] ASC);
GO

-- Creating primary key on [nIdPais] in table 'Paises'
ALTER TABLE [dbo].[Paises]
ADD CONSTRAINT [PK_Paises]
    PRIMARY KEY CLUSTERED ([nIdPais] ASC);
GO

-- Creating primary key on [nIdreceta], [nIdMedicamento], [bActivo], [nIdConsulta] in table 'Recetas'
ALTER TABLE [dbo].[Recetas]
ADD CONSTRAINT [PK_Recetas]
    PRIMARY KEY CLUSTERED ([nIdreceta], [nIdMedicamento], [bActivo], [nIdConsulta] ASC);
GO

-- Creating primary key on [nIdRol] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([nIdRol] ASC);
GO

-- Creating primary key on [nIdUsuario] in table 'USUARIOS'
ALTER TABLE [dbo].[USUARIOS]
ADD CONSTRAINT [PK_USUARIOS]
    PRIMARY KEY CLUSTERED ([nIdUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [nIdPaciente] in table 'Agenda'
ALTER TABLE [dbo].[Agenda]
ADD CONSTRAINT [FK_Agenda_Pacientes]
    FOREIGN KEY ([nIdPaciente])
    REFERENCES [dbo].[Pacientes]
        ([nIdPaciente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Agenda_Pacientes'
CREATE INDEX [IX_FK_Agenda_Pacientes]
ON [dbo].[Agenda]
    ([nIdPaciente]);
GO

-- Creating foreign key on [nIdUsuario] in table 'Agenda'
ALTER TABLE [dbo].[Agenda]
ADD CONSTRAINT [FK_Agenda_USUARIOS]
    FOREIGN KEY ([nIdUsuario])
    REFERENCES [dbo].[USUARIOS]
        ([nIdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Agenda_USUARIOS'
CREATE INDEX [IX_FK_Agenda_USUARIOS]
ON [dbo].[Agenda]
    ([nIdUsuario]);
GO

-- Creating foreign key on [nIdCampoHistClin] in table 'HitorialClinico'
ALTER TABLE [dbo].[HitorialClinico]
ADD CONSTRAINT [FK_HitorialClinico_CamposHistClin]
    FOREIGN KEY ([nIdCampoHistClin])
    REFERENCES [dbo].[CamposHistClin]
        ([nIdCampoHistClin])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HitorialClinico_CamposHistClin'
CREATE INDEX [IX_FK_HitorialClinico_CamposHistClin]
ON [dbo].[HitorialClinico]
    ([nIdCampoHistClin]);
GO

-- Creating foreign key on [nIdMunicipio] in table 'Colonias'
ALTER TABLE [dbo].[Colonias]
ADD CONSTRAINT [FK_Colonias_Municipios]
    FOREIGN KEY ([nIdMunicipio])
    REFERENCES [dbo].[Municipios]
        ([nIdMunicipio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Colonias_Municipios'
CREATE INDEX [IX_FK_Colonias_Municipios]
ON [dbo].[Colonias]
    ([nIdMunicipio]);
GO

-- Creating foreign key on [nIdColonia] in table 'Direccion'
ALTER TABLE [dbo].[Direccion]
ADD CONSTRAINT [FK_Direccion_Colonias]
    FOREIGN KEY ([nIdColonia])
    REFERENCES [dbo].[Colonias]
        ([nIdColonia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Direccion_Colonias'
CREATE INDEX [IX_FK_Direccion_Colonias]
ON [dbo].[Direccion]
    ([nIdColonia]);
GO

-- Creating foreign key on [nIdPaciente] in table 'Consulta'
ALTER TABLE [dbo].[Consulta]
ADD CONSTRAINT [FK_Consulta_Pacientes]
    FOREIGN KEY ([nIdPaciente])
    REFERENCES [dbo].[Pacientes]
        ([nIdPaciente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Consulta_Pacientes'
CREATE INDEX [IX_FK_Consulta_Pacientes]
ON [dbo].[Consulta]
    ([nIdPaciente]);
GO

-- Creating foreign key on [nIdUsuario] in table 'Consulta'
ALTER TABLE [dbo].[Consulta]
ADD CONSTRAINT [FK_Consulta_USUARIOS]
    FOREIGN KEY ([nIdUsuario])
    REFERENCES [dbo].[USUARIOS]
        ([nIdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Consulta_USUARIOS'
CREATE INDEX [IX_FK_Consulta_USUARIOS]
ON [dbo].[Consulta]
    ([nIdUsuario]);
GO

-- Creating foreign key on [nIdConsulta] in table 'Recetas'
ALTER TABLE [dbo].[Recetas]
ADD CONSTRAINT [FK_Recetas_Consulta]
    FOREIGN KEY ([nIdConsulta])
    REFERENCES [dbo].[Consulta]
        ([nIdConsulta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Recetas_Consulta'
CREATE INDEX [IX_FK_Recetas_Consulta]
ON [dbo].[Recetas]
    ([nIdConsulta]);
GO

-- Creating foreign key on [nIdEstado] in table 'Cuidades'
ALTER TABLE [dbo].[Cuidades]
ADD CONSTRAINT [FK_Cuidades_Estados]
    FOREIGN KEY ([nIdEstado])
    REFERENCES [dbo].[Estados]
        ([nIdEstado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Cuidades_Estados'
CREATE INDEX [IX_FK_Cuidades_Estados]
ON [dbo].[Cuidades]
    ([nIdEstado]);
GO

-- Creating foreign key on [nIdCuidad] in table 'Municipios'
ALTER TABLE [dbo].[Municipios]
ADD CONSTRAINT [FK_Municipios_Cuidades]
    FOREIGN KEY ([nIdCuidad])
    REFERENCES [dbo].[Cuidades]
        ([nIdCuidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Municipios_Cuidades'
CREATE INDEX [IX_FK_Municipios_Cuidades]
ON [dbo].[Municipios]
    ([nIdCuidad]);
GO

-- Creating foreign key on [nIdDireccion] in table 'Hospitales'
ALTER TABLE [dbo].[Hospitales]
ADD CONSTRAINT [FK_Hospitales_Direccion]
    FOREIGN KEY ([nIdDireccion])
    REFERENCES [dbo].[Direccion]
        ([nIdDireccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Hospitales_Direccion'
CREATE INDEX [IX_FK_Hospitales_Direccion]
ON [dbo].[Hospitales]
    ([nIdDireccion]);
GO

-- Creating foreign key on [nIdPais] in table 'Estados'
ALTER TABLE [dbo].[Estados]
ADD CONSTRAINT [FK_Estados_Paises]
    FOREIGN KEY ([nIdPais])
    REFERENCES [dbo].[Paises]
        ([nIdPais])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Estados_Paises'
CREATE INDEX [IX_FK_Estados_Paises]
ON [dbo].[Estados]
    ([nIdPais]);
GO

-- Creating foreign key on [nIdGpoSanguineo] in table 'Pacientes'
ALTER TABLE [dbo].[Pacientes]
ADD CONSTRAINT [FK_Pacientes_GposSanguineos]
    FOREIGN KEY ([nIdGpoSanguineo])
    REFERENCES [dbo].[GposSanguineos]
        ([nIdGpoSanguineo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Pacientes_GposSanguineos'
CREATE INDEX [IX_FK_Pacientes_GposSanguineos]
ON [dbo].[Pacientes]
    ([nIdGpoSanguineo]);
GO

-- Creating foreign key on [nIdPaciente] in table 'HitorialClinico'
ALTER TABLE [dbo].[HitorialClinico]
ADD CONSTRAINT [FK_HitorialClinico_Pacientes]
    FOREIGN KEY ([nIdPaciente])
    REFERENCES [dbo].[Pacientes]
        ([nIdPaciente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HitorialClinico_Pacientes'
CREATE INDEX [IX_FK_HitorialClinico_Pacientes]
ON [dbo].[HitorialClinico]
    ([nIdPaciente]);
GO

-- Creating foreign key on [nIdHospital] in table 'USUARIOS'
ALTER TABLE [dbo].[USUARIOS]
ADD CONSTRAINT [FK_USUARIOS_Hospitales]
    FOREIGN KEY ([nIdHospital])
    REFERENCES [dbo].[Hospitales]
        ([nIdHospital])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_USUARIOS_Hospitales'
CREATE INDEX [IX_FK_USUARIOS_Hospitales]
ON [dbo].[USUARIOS]
    ([nIdHospital]);
GO

-- Creating foreign key on [nIdMedicamento] in table 'Recetas'
ALTER TABLE [dbo].[Recetas]
ADD CONSTRAINT [FK_Recetas_Medicamentos]
    FOREIGN KEY ([nIdMedicamento])
    REFERENCES [dbo].[Medicamentos]
        ([nIdMedicamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Recetas_Medicamentos'
CREATE INDEX [IX_FK_Recetas_Medicamentos]
ON [dbo].[Recetas]
    ([nIdMedicamento]);
GO

-- Creating foreign key on [nIdRol] in table 'USUARIOS'
ALTER TABLE [dbo].[USUARIOS]
ADD CONSTRAINT [FK_USUARIOS_Roles]
    FOREIGN KEY ([nIdRol])
    REFERENCES [dbo].[Roles]
        ([nIdRol])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_USUARIOS_Roles'
CREATE INDEX [IX_FK_USUARIOS_Roles]
ON [dbo].[USUARIOS]
    ([nIdRol]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------