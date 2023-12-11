CREATE DATABASE clayBioSecurity;

USE clayBioSecurity;

-- Country Table
CREATE TABLE IF NOT EXISTS country (
    id INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT pk_idCountry PRIMARY KEY(id)
);

-- Department Table
CREATE TABLE IF NOT EXISTS department (
    id INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(50) NOT NULL,
    fkIdCountry INT NOT NULL,
    CONSTRAINT pk_idDepartment PRIMARY KEY(id),
    CONSTRAINT fk_idCountry FOREIGN KEY(fkIdCountry) REFERENCES country(id)
);

-- Town Table
CREATE TABLE IF NOT EXISTS town (
    id INT AUTO_INCREMENT NOT NULL,
    name VARCHAR(50) NOT NULL,
    fkIdDepartment INT NOT NULL,
    CONSTRAINT pk_idTown PRIMARY KEY(id),
    CONSTRAINT fk_idDepartment FOREIGN KEY(fkIdDepartment) REFERENCES department(id)
);

-- personType Table
CREATE TABLE IF NOT EXISTS personType (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(50) NOT NULL,
    CONSTRAINT pk_idPersonType PRIMARY KEY(id)
);

-- personCategory Table
CREATE TABLE IF NOT EXISTS personCategory (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(50) NOT NULL,
    CONSTRAINT pk_idPersonCategory PRIMARY KEY(id)
);

-- contactType Table
CREATE TABLE IF NOT EXISTS contactType (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(50) NOT NULL,
    CONSTRAINT pk_idContactType PRIMARY KEY(id)
);

-- addressType Table
CREATE TABLE IF NOT EXISTS addressType (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(50) NOT NULL,
    CONSTRAINT pk_idAddressType PRIMARY KEY(id)
);

-- contractStatus Table
CREATE TABLE IF NOT EXISTS contractStatus (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(50) NOT NULL,
    CONSTRAINT pk_idContractStatus PRIMARY KEY(id)
);

-- workShifts Table
CREATE TABLE IF NOT EXISTS workShifts (
    id INT AUTO_INCREMENT NOT NULL,
    Name VARCHAR(50) NOT NULL,
    shiftStartTime DATETIME NOT NULL,
    shiftEndTime DATETIME NOT NULL,
    CONSTRAINT pk_idWorkShifts PRIMARY KEY(id)
);

-- person Table
CREATE TABLE IF NOT EXISTS person (
    id INT AUTO_INCREMENT NOT NULL,
    idperson VARCHAR(15) NOT NULL UNIQUE,
    name VARCHAR(50) NOT NULL,
    creationDate DATETIME NOT NULL,
    fkIdPersonType INT NOT NULL,
    fkIdPersonCate INT NOT NULL,
    fkIdTown INT NOT NULL,
    CONSTRAINT pk_idperson PRIMARY KEY(id),
    CONSTRAINT fk_idPersonType FOREIGN KEY(fkIdPersonType) REFERENCES personType(id),
    CONSTRAINT fk_idPersonCate FOREIGN KEY(fkIdPersonCate) REFERENCES personCategory(id),
    CONSTRAINT fk_idTown FOREIGN KEY(fkIdTown) REFERENCES town(id)
);

-- address Table
CREATE TABLE IF NOT EXISTS address (
    id INT AUTO_INCREMENT NOT NULL,
    address VARCHAR(60) NOT NULL,
    fkIdPerson INT NOT NULL,
    fkIdAddressType INT NOT NULL,
    CONSTRAINT pk_idAddress PRIMARY KEY(id),
    CONSTRAINT fk_idEmployee FOREIGN KEY(fkIdPerson) REFERENCES person(id),
    CONSTRAINT fk_idAddressType FOREIGN KEY(fkIdAddressType) REFERENCES addressType(id)
);


-- personContact Table
CREATE TABLE IF NOT EXISTS personContact (
    id INT AUTO_INCREMENT NOT NULL,
    description VARCHAR(60) NOT NULL,
    fkIdPerson INT NOT NULL,
    fkIdContactType INT NOT NULL,
    CONSTRAINT pk_idPersonContact PRIMARY KEY(id),
    CONSTRAINT fk_idPersonCont FOREIGN KEY(fkIdPerson) REFERENCES person(id),
    CONSTRAINT fk_idContactType FOREIGN KEY(fkIdContactType) REFERENCES contactType(id)
);

-- contract Table
CREATE TABLE IF NOT EXISTS contract (
    id INT AUTO_INCREMENT NOT NULL,
    contractStartDate DATETIME NOT NULL,
    contractEndDate DATETIME NOT NULL,
    fkIdClient INT NOT NULL,
    fkIdEmployee INT NOT NULL,
    fkIdContractStatus INT NOT NULL,
    CONSTRAINT pk_idContract PRIMARY KEY(id),
    CONSTRAINT fk_idClientContract FOREIGN KEY(fkIdClient) REFERENCES person(id),
    CONSTRAINT fk_idEmployeeContract FOREIGN KEY(fkIdEmployee) REFERENCES person(id),
    CONSTRAINT fk_idContractStatus FOREIGN KEY(fkIdContractStatus) REFERENCES contractStatus(id)
);

-- shiftScheduling Table
CREATE TABLE IF NOT EXISTS shiftScheduling (
    id INT AUTO_INCREMENT NOT NULL,
    fkIdContract INT NOT NULL,
    fkIdPerson INT NOT NULL,
    fkIdWorkShifts INT NOT NULL,
    CONSTRAINT pk_idShiftScheduling PRIMARY KEY(id),
    CONSTRAINT fk_idContract FOREIGN KEY(fkIdContract) REFERENCES contract(id),
    CONSTRAINT fk_idEmploShiftSche FOREIGN KEY(fkIdPerson) REFERENCES person(id),
    CONSTRAINT fk_idWorkShifts FOREIGN KEY(fkIdWorkShifts) REFERENCES workShifts(id)
);