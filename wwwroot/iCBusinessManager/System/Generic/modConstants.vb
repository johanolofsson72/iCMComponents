Module Constants
    ' DataSource
    Public Const ICM_DATASOURCE_MSSQLSERVER = "MSSQLServer"
    Public Const ICM_DATASOURCE_MSACCESS = "MSAccess"
    Public Const ICM_DATASOURCE_MYSQL = "MySql"

    ' DataSet Calculation
    Public Const DSE_INVALID_TYPE = 0
    Public Const DSE_UPDATE_SINGLE = 1
    Public Const DSE_UPDATE_MULTI = 2
    Public Const DSE_SAVE_SINGLE = 3
    Public Const DAT_TABLE_LBOUND = 0
    Public Const DAT_COLUMN_LBOUND = 0
    Public Const DAT_ROW_LBOUND = 0
    Public Const DAT_MAX_PKIDCOL = "iCMServer_Temporary_Column"

    ' Errors are described in a matrix with the following columns
    Public Const ERR_POS_NUMBER = 1
    Public Const ERR_POS_SEVERITY = 2
    Public Const ERR_POS_SOURCE = 3
    Public Const ERR_POS_MSG = 4
    Public Const ERR_POS_MAX = ERR_POS_MSG

    ' Error severity
    Public Const ERR_SEVERITY_INFO = 0
    Public Const ERR_SEVERITY_WARNING = 1
    Public Const ERR_SEVERITY_ABORT = 2
    Public Const ERR_SEVERITY_PROGRAMMING_ERROR = 3
    Public Const ERR_SEVERITY_UNKNOWN = 9
    Public Const ERR_SEVERITY_MORTAL = 666

    ' Error numbers
    Public Const ERR_BASE_NUMBER = 65000
    Public Const ERR_ABORT = ERR_BASE_NUMBER + 1
    Public Const ERR_INVALID_FUNCTION = ERR_BASE_NUMBER + 2
    Public Const ERR_INVALID_NUMBER_OF_PARAMETERS = ERR_BASE_NUMBER + 3
    Public Const ERR_CREATEOBJECTX = ERR_BASE_NUMBER + 4
    Public Const ERR_BRAINDEADPROGRAMMER = ERR_BASE_NUMBER + 5
    Public Const ERR_INVALID_RESULT_FORMAT = ERR_BASE_NUMBER + 6
    Public Const ERR_QUE_NOT_FOUND_IN_UST = ERR_BASE_NUMBER + 7
    Public Const ERR_INVALID_CALL = ERR_BASE_NUMBER + 8
    Public Const ERR_SERVERSETTINGS_NOT_FOUND = ERR_BASE_NUMBER + 9
    Public Const ERR_LOGIN_FAILED = ERR_BASE_NUMBER + 10
    Public Const ERR_INVALID_SESSION = ERR_BASE_NUMBER + 11
    Public Const ERR_INVALID_VALIDATION_OBJECT = ERR_BASE_NUMBER + 12
    Public Const ERR_SELFREGISTRATION_NOT_PERMITTED = ERR_BASE_NUMBER + 13
    Public Const ERR_SELFREGISTRATION_WRONG_PASSWORD = ERR_BASE_NUMBER + 14
    Public Const ERR_SERVERSETTING_NOT_FOUND = ERR_BASE_NUMBER + 15
    Public Const ERR_LOCALEINFO_FAILED = ERR_BASE_NUMBER + 16
    Public Const ERR_MAIL_ADDRESS = ERR_BASE_NUMBER + 17
    Public Const ERR_UNKNOWN_DATASOURCE = ERR_BASE_NUMBER + 18
    Public Const ERR_INVALID_CONNECTIONSTRING = ERR_BASE_NUMBER + 19
    Public Const ERR_CLOSE_CONNECTION = ERR_BASE_NUMBER + 20
    Public Const ERR_GETDATA = ERR_BASE_NUMBER + 21
    Public Const ERR_GETDATASET = ERR_BASE_NUMBER + 22
    Public Const ERR_GETEMPTYDATASET = ERR_BASE_NUMBER + 23
    Public Const ERR_CONCATE_SQL = ERR_BASE_NUMBER + 24
    Public Const ERR_VALIDATE_SQL = ERR_BASE_NUMBER + 25
    Public Const ERR_ENCRYPT = ERR_BASE_NUMBER + 26
    Public Const ERR_DECRYPT = ERR_BASE_NUMBER + 27
    Public Const ERR_SAVEDATASET = ERR_BASE_NUMBER + 28
    Public Const ERR_MAXPKIDCOL_QUESTION = ERR_BASE_NUMBER + 29
    Public Const ERR_EMPTYDATASET_QUESTION = ERR_BASE_NUMBER + 30
    Public Const ERR_GET_MAXPKIDCOL = ERR_BASE_NUMBER + 31
    Public Const ERR_CLEAR_DATASET = ERR_BASE_NUMBER + 32

    ' System.Security.Cryptography.Rijndael symmetric encryption algorithm
    Public CRYPTO_KEY As Byte() = {&H15, &H2, &H3, &H44, &H5, &H6, &HF7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
    Public CRYPTO_IV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

End Module
