namespace MessageSender.Application.Common.Enums;

/// <summary>
/// Represents the status code of the result for internal microservices.
/// </summary>
public enum StatusCodes : short
{
    /// <summary>
    /// User status - self-exclusion.
    /// </summary>
    StatusIdSelfExclude = -1,

    /// <summary>
    /// User status - self-suspension.
    /// </summary>
    StatusIdSuspend = 0,

    /// <summary>
    /// User status - registered.
    /// </summary>
    StatusIdRegistered = 1,

    /// <summary>
    /// Operation was successful.
    /// </summary>
    Success = 10,

    /// <summary>
    /// Received request had invalid structure.
    /// </summary>
    WrongRequest = 99,

    /// <summary>
    /// Value specified in the field has reached its limit.
    /// </summary>
    FieldLimitReached = 100,

    /// <summary>
    /// Value specified in the field does not meet Min / Max requirements.
    /// </summary>
    FieldMinMaxNotMatched = 101,

    /// <summary>
    /// Value specified in the field does not meet its format requirements.
    /// </summary>
    FieldFormatNotMatched = 102,

    /// <summary>
    /// Required field is empty.
    /// </summary>
    FieldIsEmpty = 103,

    /// <summary>
    /// Value specified in the field does not meet its pattern requirements.
    /// </summary>
    PatternIsNotMatched = 104,

    /// <summary>
    /// Specified country is not supported by the system.
    /// </summary>
    CountryNotSupported = 105,

    /// <summary>
    /// Specified age of the user does not meet system defined requirements.
    /// </summary>
    AgeLimitNotMatched = 106,

    /// <summary>
    /// ID Document of the user must be specified.
    /// </summary>
    IdDocumentIsMissing = 107,

    /// <summary>
    /// IP has reached its limit for number of registrations allowed.
    /// </summary>
    MaxPossibleRegPerIpReached = 108,

    /// <summary>
    /// ID Document of the user could not be saved.
    /// </summary>
    UnableToSaveIdDoc = 109,

    /// <summary>
    /// Can not assign the payment account to the user.
    /// </summary>
    UnableToAssignAccountToUser = 110,

    /// <summary>
    /// Generic error.
    /// </summary>
    GenericFailedError = 111,

    /// <summary>
    /// The request payload has a missing parameter.
    /// </summary>
    MissingParameters = 112,

    /// <summary>
    /// Specified user identifier or password was incorrect.
    /// </summary>
    UserWithGivenAuthCredentialsNotFound = 113,

    /// <summary>
    /// Reached maximum number of OTP send requests.
    /// </summary>
    OtpRequestLimitReached = 114,

    /// <summary>
    /// The user has no phone number assigned to it.
    /// </summary>
    UnableToSendOtpTelIsMissing = 115,

    /// <summary>
    /// Could not send high security enable OTP.
    /// </summary>
    UnableToSendSmsCodeOtpIsEnabled = 116,

    /// <summary>
    /// OTP code could not be sent.
    /// </summary>
    FailedToSendOtp = 117,

    /// <summary>
    /// OTP code has been sent to the user.
    /// </summary>
    OtpIsSent = 118,

    /// <summary>
    /// Specified otp code was incorrect.
    /// </summary>
    OtpNotFound = 119,

    /// <summary>
    /// High security mode is not activated for the user.
    /// </summary>
    OtpIsNotEnabled = 120,

    /// <summary>
    /// Unable to generate OTP.
    /// </summary>
    UnableToGenerateOtp = 121,

    /// <summary>
    /// User has high security enabled and no OTP was provided.
    /// </summary>
    OtpIsRequired = 122,

    /// <summary>
    /// The last requester IP for the session was different from the current one.
    /// </summary>
    LastAccessFromDifferentIp = 123,

    /// <summary>
    /// Provided IP address is blocked.
    /// </summary>
    IpIsBlocked = 124,

    /// <summary>
    /// Specified user account can not be found.
    /// </summary>
    AccountNotFound = 125,

    /// <summary>
    /// Specified user has no active session.
    /// </summary>
    SessionNotFound = 126,

    /// <summary>
    /// The old and new values match, the value can not be updated.
    /// </summary>
    OldAndNewValuesMatchError = 127,

    /// <summary>
    /// The user has no contact details assigned.
    /// </summary>
    ContactDetailsNotAssigned = 128,

    /// <summary>
    /// Provided contact detail information is invalid.
    /// </summary>
    ContactDetailNotMatched = 129,

    /// <summary>
    /// The user has no phone number assigned to it.
    /// </summary>
    UnableToEnableOtpTelIsMissing = 130,

    /// <summary>
    /// User account is blocked.
    /// </summary>
    AccountIsBlocked = 131,

    /// <summary>
    /// High security mode is disabled for the user.
    /// </summary>
    OtpIsOff = 132,

    /// <summary>
    /// ID document already exist.
    /// </summary>
    UserHasGivenIdDoc = 133,

    /// <summary>
    /// High security mode is activated for the user.
    /// </summary>
    OtpIsEnabled = 134,

    /// <summary>
    /// Document with the specified id can not be found.
    /// </summary>
    UsersDocumentNotFound = 135,

    /// <summary>
    /// ID document already has a photo.
    /// </summary>
    DocumentPhotoAlreadyExists = 136,

    /// <summary>
    /// Could not find the provider id.
    /// </summary>
    ProviderNotFound = 137,

    /// <summary>
    /// Access is denied for current operation.
    /// </summary>
    AccessDenied = 138,

    /// <summary>
    /// The request hash in incorrect or missing.
    /// </summary>
    WrongHash = 139,

    /// <summary>
    /// Access granted.
    /// </summary>
    AccessGranted = 140,

    /// <summary>
    /// The user has self-exclusion limit.
    /// </summary>
    UserIsSelfExcluded = 141,

    /// <summary>
    /// Dates are invalid.
    /// </summary>
    WrongDates = 142,

    /// <summary>
    /// The value can not be negative.
    /// </summary>
    CanNotBeNegative = 143,

    /// <summary>
    /// The value must be more than 0.
    /// </summary>
    MustBeMoreThanZero = 144,

    /// <summary>
    /// Specified currency could not be found.
    /// </summary>
    CurrencyNotFound = 145,

    /// <summary>
    /// User has no account in the specified currency.
    /// </summary>
    UsersAccountsNotFound = 146,

    /// <summary>
    /// Specified token could not be found.
    /// </summary>
    TokenNotFound = 147,

    /// <summary>
    /// Specified token is expired.
    /// </summary>
    TokenIsExpired = 148,

    /// <summary>
    /// Specified status id is invalid.
    /// </summary>
    IncorrectUserStatusId = 149,

    /// <summary>
    /// Provider doesn't have the access to perform the operation.
    /// </summary>
    AccessDeniedForGivenProvider = 150,

    /// <summary>
    /// Specified provider transaction id already exists.
    /// </summary>
    DuplicatedProvidersTransactionId = 151,

    /// <summary>
    /// No preferred currency is specified.
    /// </summary>
    PrimaryCurrencyNotFound = 152,

    /// <summary>
    /// Transaction amount breaches the limit rules.
    /// </summary>
    TransactionAmountAndLimitDontMatch = 153,

    /// <summary>
    /// Insufficient funds on the account.
    /// </summary>
    InsufficientFunds = 154,

    /// <summary>
    /// Transaction id format is invalid.
    /// </summary>
    IncorrectTransactionIdFormat = 155,

    /// <summary>
    /// Couldn't find transaction with the given id.
    /// </summary>
    TransactionNotFound = 156,

    /// <summary>
    /// Transaction status is - SUCCESS.
    /// </summary>
    TransactionStatusSuccess = 157,

    /// <summary>
    /// Transaction status is - ROLLBACK.
    /// </summary>
    TransactionStatusRollback = 158,

    /// <summary>
    /// User account is suspended.
    /// </summary>
    AccountIsSuspended = 159,

    /// <summary>
    /// Unable to get user balance.
    /// </summary>
    UnableToGetBalance = 170,

    /// <summary>
    /// Unable to exchange between currencies.
    /// </summary>
    UnableToExchange = 171,

    /// <summary>
    /// Rollback time limit expired.
    /// </summary>
    TransactionRollbackTimeExpired = 172,

    /// <summary>
    /// Unable to rollback transaction.
    /// </summary>
    UnableToRollbackTransaction = 173,

    /// <summary>
    /// Payment account with the specified id not found.
    /// </summary>
    PaymentAccountNotFound = 174,

    /// <summary>
    /// Specified payment account is not verified.
    /// </summary>
    PaymentAccountIsNotVerified = 175,

    /// <summary>
    /// Exchange rate between currencies is not specified.
    /// </summary>
    ExchangeRateNotFound = 176,

    /// <summary>
    /// Approval is not required for card verification transaction.
    /// </summary>
    CardVerificationTransactionDoesNotRequireApproval = 177,

    /// <summary>
    /// Couldn't identify transaction status.
    /// </summary>
    UnidentifiedTransactionStatus = 178,

    /// <summary>
    /// Transaction can not be updated from the current status to the specified one.
    /// </summary>
    UnableToChangeTransactionStatusFromCurrentStatus = 179,

    /// <summary>
    /// Unable to change transaction status.
    /// </summary>
    UnableToChangeTransactionStatus = 180,

    /// <summary>
    /// Transaction status is - APPROVED.
    /// </summary>
    TransactionStatusApproved = 181,

    /// <summary>
    /// Transaction status is - PENDING.
    /// </summary>
    TransactionStatusPending = 182,

    /// <summary>
    /// Transaction status is - REJECTED.
    /// </summary>
    TransactionStatusRejected = 183,

    /// <summary>
    /// Transaction status is - FROZEN.
    /// </summary>
    TransactionStatusFrozen = 184,

    /// <summary>
    /// Transaction status is - CANCELED.
    /// </summary>
    TransactionStatusCanceled = 185,

    /// <summary>
    /// Specified provider is disabled.
    /// </summary>
    ProviderIsDisabled = 186,

    /// <summary>
    /// Couldn't verify provided parameters.
    /// </summary>
    FailedToVerifyParameters = 187,

    /// <summary>
    /// Specified registration profile doesn't exist.
    /// </summary>
    RegistrationProfileNotFound = 188,

    /// <summary>
    /// Origin domain is not allowed.
    /// </summary>
    OriginDomainNotAllowed = 189,

    /// <summary>
    /// Email couldn't be sent because user has no email specified.
    /// </summary>
    UnableToSendEmailVerificationEmailIsMissing = 190,

    /// <summary>
    /// The specified value can not be less than the old one.
    /// </summary>
    FieldNewValueCanNotBeLessThanCurrentValue = 191,

    /// <summary>
    /// Specified T&C could not be found.
    /// </summary>
    TermsAndConditionNotFound = 192,

    /// <summary>
    /// User has no registration domain specified.
    /// </summary>
    UserIsMissingRegistrationDomain = 193,

    /// <summary>
    /// Specified T&C could not be accepted.
    /// </summary>
    UnableToAcceptProvidedTerms = 194,

    /// <summary>
    /// User is required to accept specific T&C for the operation.
    /// </summary>
    UserHasToAcceptRequiredTerms = 195,

    /// <summary>
    /// Transaction status is - RETURN.
    /// </summary>
    TransactionStatusReturn = 196,

    /// <summary>
    /// Specified contact channel is not verified.
    /// </summary>
    ContactChannelNotVerified = 197,

    /// <summary>
    /// Date of birth is not specified for the user.
    /// </summary>
    UserIsMissingDateOfBirth = 198,

    /// <summary>
    /// Card verification transaction can not be a bonus transaction.
    /// </summary>
    CardVerificationTransactionCannotParticipateInBonus = 199,

    /// <summary>
    /// Provided entry already exists.
    /// </summary>
    StatusItemExists = 200,

    /// <summary>
    /// Cash transaction can not be a bonus transaction.
    /// </summary>
    CashTransactionCannotParticipateInBonus = 201,

    /// <summary>
    /// Bonus with specified parameters doesn't exist.
    /// </summary>
    BonusWithSpecifiedParametersNotFound = 202,

    /// <summary>
    /// Bonus is missing allowed games list.
    /// </summary>
    BonusIsMissingAllowedGamesList = 203,

    /// <summary>
    /// Specified provider is not allowed for the bonus.
    /// </summary>
    ProviderServiceIsNotAllowedToUseBonus = 204,

    /// <summary>
    /// Bonus is expired.
    /// </summary>
    BonusIsExpired = 205,

    /// <summary>
    /// Unable to modify corrupted transaction.
    /// </summary>
    UnableToModifyCorruptedTransaction = 206,

    /// <summary>
    /// Image file name is invalid.
    /// </summary>
    InvalidImageFileName = 207,

    /// <summary>
    /// Old and new statuses are the same.
    /// </summary>
    StatusCannotBeChangeToGivenNewStatus = 208,

    /// <summary>
    /// External authentication system is disabled.
    /// </summary>
    ThirdPartyAuthSystemDisabled = 209,

    /// <summary>
    /// External authentication system is not allowed.
    /// </summary>
    ThirdPartyAuthSystemNotAllowed = 210,

    /// <summary>
    /// Specified payment account already exists.
    /// </summary>
    PaymentAccountAlreadyExists = 211,

    /// <summary>
    /// Can not check the session with exposed session id.
    /// </summary>
    SessionCheckWithExposedSessionIdNotAllowed = 212,

    /// <summary>
    /// User registration and origin domains don't match.
    /// </summary>
    UserDoesNotBelongToOriginDomain = 213,

    /// <summary>
    /// Transaction fee can not be 0, it should be null or more than 0.
    /// </summary>
    TxFeeMustBeNullOrMoreThanZero = 214,

    /// <summary>
    /// Provider's transaction fees can not be overriden.
    /// </summary>
    ProvidedTxFeeCanNotOverrideProvidersTxFees = 215,

    /// <summary>
    /// Specified transaction reference id already exists.
    /// </summary>
    ProviderTxReferenceIdIsAlreadySet = 216,

    /// <summary>
    /// Amount is less than minimum allowed amount.
    /// </summary>
    ProviderMinAmountIsGreaterThanAmount = 217,

    /// <summary>
    /// Maximum deposit amount reached.
    /// </summary>
    DepositLimitReached = 218,

    /// <summary>
    /// Maximum wager amount reached.
    /// </summary>
    WagerLimitReached = 219,

    /// <summary>
    /// Maximum loss amount reached.
    /// </summary>
    LossLimitReached = 220,

    /// <summary>
    /// Transaction type not allowed.
    /// </summary>
    TransactionTypeNotAllowed = 221,

    /// <summary>
    /// User has active limit in different currency.
    /// </summary>
    UserHasActiveLimitInDifferentCurrency = 222,

    /// <summary>
    /// Specified value is already set.
    /// </summary>
    ValueIsAlreadySet = 223,

    /// <summary>
    /// Currency doesn't exist or is virtual.
    /// </summary>
    CurrencyNotFoundOrIsVirtual = 224,

    /// <summary>
    /// Maximum financial limit reached.
    /// </summary>
    FinancialLimitReached = 225,

    /// <summary>
    /// Reality check time limit reached.
    /// </summary>
    RealityCheckIsDue = 226,

    /// <summary>
    /// Reality check time limit is not yet reached.
    /// </summary>
    RealityCheckIsNotDueYet = 227,

    /// <summary>
    /// ID document with current status can not be changed.
    /// </summary>
    IdDocumentWithCurrentStatusCanNotBeAltered = 228,

    /// <summary>
    /// ID document is expired.
    /// </summary>
    IdDocumentIsExpired = 229,

    /// <summary>
    /// ID document has no scanned images.
    /// </summary>
    IdDocumentIsMissingScannedImages = 230,

    /// <summary>
    /// Provider transaction session status is invalid.
    /// </summary>
    InvalidProviderTransactionSessionStatus = 231,

    /// <summary>
    /// Denied to open transaction session.
    /// </summary>
    NotAllowedToOpenTransactionSession = 232,

    /// <summary>
    /// Card verification can not be part of transaction session.
    /// </summary>
    CardVerificationCannotBePartOfTransactionSession = 233,

    /// <summary>
    /// Card verification amount must be more than 0.
    /// </summary>
    CardVerificationAmountMustBeMoreThanZero = 234,

    /// <summary>
    /// Bonus amount can not be negative.
    /// </summary>
    BonusAmountCanNotBeNegative = 235,

    /// <summary>
    /// Session must be closed on 0 amount transaction.
    /// </summary>
    ZeroAmountTransactionMustCloseSession = 236,

    /// <summary>
    /// 0 amount session close transaction can not require approval.
    /// </summary>
    ZeroAmountSessionCloseTxCanNotRequireApproval = 237,

    /// <summary>
    /// Provider transaction reference id is required.
    /// </summary>
    ProviderTxReferenceIdIsRequired = 238,

    /// <summary>
    /// Transaction session is closed.
    /// </summary>
    TransactionSessionIsClosed = 239,

    /// <summary>
    /// Cash transaction can not be part of transaction session.
    /// </summary>
    CashTransactionCannotBePartOfTransactionSession = 240,

    /// <summary>
    /// 0 amount session open transaction can not require approval.
    /// </summary>
    ZeroAmountSessionOpenTxCanNotRequireApproval = 241,

    /// <summary>
    /// 0 amount transaction can not have a bonus amount.
    /// </summary>
    BonusAwardIdMustBeNullForZeroAmountTx = 242,

    /// <summary>
    /// Transaction in provider transaction session is waiting for approval.
    /// </summary>
    TransactionInProviderTransactionSessionIsWaitingForApproval = 244,

    /// <summary>
    /// Payment provider is not allowed to perform rollback with tx reference id.
    /// </summary>
    PaymentProviderIsNotAllowedToPerformRollbackWithTxReferenceId = 245,

    /// <summary>
    /// Subsequent tx in provider transaction session is pending transaction.
    /// </summary>
    SubsequentTxInProviderTransactionSessionIsPendingTransaction = 246,

    /// <summary>
    /// Transaction is not last in provider transaction session.
    /// </summary>
    TransactionIsNotLastInProviderTransactionSession = 247,

    /// <summary>
    /// Failed to verify provider transaction session.
    /// </summary>
    FailedToVerifyProviderTransactionSession = 248,

    /// <summary>
    /// Transaction fee cannot be applied to card verification transaction.
    /// </summary>
    TransactionFeeCannotBeAppliedToCardVerificationTransaction = 249,

    /// <summary>
    /// Transaction amount checksum error.
    /// </summary>
    TransactionAmountChecksumError = 250,

    /// <summary>
    /// Fee can not be more than transaction amount.
    /// </summary>
    FeeExceedsTransactionAmount = 251,

    /// <summary>
    /// Not allowed to set provider tx reference id to existing game tx.
    /// </summary>
    NotAllowedToSetProviderTxReferenceIdToExistingGameTx = 252,

    /// <summary>
    /// Valid transaction session not found.
    /// </summary>
    ValidTransactionSessionNotFound = 253,

    /// <summary>
    /// Failed to retrieve active bonus balance.
    /// </summary>
    FailedToRetrieveActiveBonusBalance = 254,

    /// <summary>
    /// User validation with regulator service has failed with system error.
    /// </summary>
    UserValidationWithRegulatorServiceHasFailedWithSystemError = 255,

    /// <summary>
    /// User is blacklisted by regulator service.
    /// </summary>
    UserIsBlacklistedByRegulatorService = 256,

    /// <summary>
    /// Query not allowed.
    /// </summary>
    QueryNotAllowed = 257,

    /// <summary>
    /// Auth credentials do not match.
    /// </summary>
    AuthCredentialsDoesNotMatch = 258,

    /// <summary>
    /// User is blocked for malicious activity.
    /// </summary>
    UserIsBlockedForMaliciousActivity = 259,

    /// <summary>
    /// Alteration is not allowed for the field.
    /// </summary>
    AlterationNotAllowed = 260,

    /// <summary>
    /// Value not allowed to be changed.
    /// </summary>
    ValueNotAllowedToBeSet = 261,

    /// <summary>
    /// Failed to set mandatory session limit.
    /// </summary>
    FailedToSetMandatorySessionLimit = 262,

    /// <summary>
    /// User is blocked by the regulatory requirements.
    /// </summary>
    UserRegulatoryExcluded = 265,

    /// <summary>
    /// Requested entry does not exist.
    /// </summary>
    StatusItemDoesNotExists = 400,

    /// <summary>
    /// Not found status code for general purposes.
    /// </summary>
    NotFound = 404,

    /// <summary>
    /// Status unable to check requested entry.
    /// </summary>
    StatusUnableToCheckItem = 500,

    /// <summary>
    /// General operation fail.
    /// </summary>
    OperationFailed = 505,

    /// <summary>
    /// Operation fail with unknown error.
    /// </summary>
    ErrorCodeNotFound = 1001,

    /// <summary>
    /// Maximum possible number of payment accounts for the user.
    /// </summary>
    MaxPossiblePayAccountsReachedPerUser = 1100,

    /// <summary>
    /// Maximum possible number of payment accounts for the system.
    /// </summary>
    MaxPossiblePayAccountsReachedInSystem = 1101,

    /// <summary>
    /// Provider service is unreachable.
    /// </summary>
    UnreachableProviderService = 1111,

    /// <summary>
    /// Voucher code is already used.
    /// </summary>
    VoucherIsUsed = 1200,

    /// <summary>
    /// Voucher code is inactive.
    /// </summary>
    VoucherNotActive = 1201,

    /// <summary>
    /// Voucher not found.
    /// </summary>
    VoucherNotFound = 1202,

    /// <summary>
    /// Voucher code expired.
    /// </summary>
    VoucherExpired = 1203
}