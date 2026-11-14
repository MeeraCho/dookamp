# User Management Requirements

## 1. Overview

DOOKAMP uses a unified User Account model. Each account can manage multiple Profiles, and each Profile represents an individual learner.

The system supports account authentication, Profile management, learning access, content management, and administrative operations.

### 1.1 Core Concepts

- **User Account:** An account used to authenticate and access DOOKAMP.
- **Profile:** An individual learner's profile associated with a User Account.
- **Role:** Defines the permissions available to a User Account.
- **Audit Log:** Records important administrative and content management activities.

### 1.2 User Account Structure

- Anyone can create a User Account.
- A User Account can have up to five Profiles.
- The account owner can create a Profile for themselves or other family members.
- Parent and Student are not separate account types.
- All Roles can access general learning features.

## 2. Authentication

### 2.1 Supported Login Methods

- Email and Password
- Google Login

Email is the account's unique login identifier.

- Email addresses must be unique.
- Email comparison must be case-insensitive.
- No separate username is required.

### 2.2 Email Registration

- Users register with an email address and password.
- Email verification is required before accessing learning features.
- Users can request a new verification email.
- Verification links expire after 24 hours.
- Requesting a new verification link invalidates the previous link.

### 2.3 Google Login

- Google Login is supported from the beginning of the MVP.
- Google accounts with `email_verified = true` can access DOOKAMP without additional email verification.
- If a Google account uses an email address that already belongs to an existing DOOKAMP account, it is automatically linked when Google's verified email matches the existing account email.
- Both login methods access the same User Account and Profiles.
- Google account linking does not create duplicate User Accounts.
- Google account unlinking is not supported in the MVP.

### 2.4 Email Verification Restrictions

Before email verification:

- Users can log in.
- Learning features are unavailable.
- An email verification guidance screen is displayed.
- Users can request another verification email.

After successful verification, all normal features become available.

## 3. Profile Management

### 3.1 Profile Rules

- Each User Account can have a maximum of five Profiles.
- Each User Account must maintain at least one Profile.
- A Profile represents one individual learner.
- Profiles are independently configurable.
- Users can only manage Profiles belonging to their own account.

### 3.2 Profile Fields

Each Profile contains:

- `Name`
- `AvatarKey`
- `GradeId`
- `LocationId`
- `UILanguageCode`
- `PrimaryLanguageCode`
- `SecondaryLanguageCode` (nullable)

Language fields reference the existing Language entity.

### 3.3 Default Profile Creation

A Profile is automatically created after successful registration.

The same behavior applies to Email + Password registration and Google registration.

Default values:

| Field | Default |
|---|---|
| Name | Registration email address |
| AvatarKey | Default built-in avatar |
| Grade | Grade 1 |
| Location | Alberta |
| UI Language | en |
| Primary Text Language | en |
| Secondary Text Language | null (OFF) |

The Profile name can be edited later.

Changing the account email does not automatically change the Profile name.

### 3.4 Avatar

- Only predefined avatars are supported in the MVP.
- Custom avatar uploads are not supported.
- Avatar images are represented by an `AvatarKey`.
- Example key: `fox-01`.

### 3.5 Profile Update

Users can independently update:

- Name
- Avatar
- Grade
- Location
- UI Language
- Primary Text Language
- Secondary Text Language

### 3.6 Profile Deletion

- Users can delete their own Profiles.
- The last remaining Profile cannot be deleted.
- Deletion requires explicit confirmation.
- The confirmation message must explain that associated learning data will also be permanently deleted.
- Associated learning data includes learning progress, quiz results, XP, achievements, and learning history.
- Deleting a Profile does not delete the User Account.

## 4. Profile Selection

- If an account has only one Profile, it is selected automatically.
- If an account has multiple Profiles, a Profile selection screen is displayed after login.
- The last used Profile is selected by default.
- Switching Profiles updates the last-used Profile.
- If the last-used Profile has been deleted, another available Profile is selected automatically.
- Each device maintains its own currently selected Profile.
- Switching Profiles on one device does not change the active Profile on another device.

## 5. Account Management

### 5.1 Account Information

Users can retrieve their current account information:

- User ID
- Email
- Email confirmation status
- Account status
- Profile list
- Last-used Profile

Account statuses:

- `Active`
- `PendingDeletion`
- `Disabled`

### 5.2 Change Email

- Users can change their account email.
- The current password is required before changing email.
- Google-only accounts must re-authenticate with Google.
- The new email must be unique.
- A verification link is sent to the new email address.
- The existing email remains active until the new email is verified.
- The old email receives a notification after the change is completed.
- All login sessions are invalidated after a successful email change.
- Email verification links expire after 24 hours.
- Requesting a new verification link invalidates the previous link.

### 5.3 Change Password

- Users can change their password while logged in.
- The current password is required.
- The new password must follow the password policy.
- The current device remains logged in.
- All other device sessions are invalidated.

Google-only accounts do not have a DOOKAMP password by default.

### 5.4 Forgot Password and Reset Password

- Users can request a password reset email.
- Reset links expire after one hour.
- Expired links cannot be used.
- Users can request a new reset link.
- All login sessions are invalidated after a successful password reset.
- The device used for password reset is also logged out.
- Users must log in again with the new password.

For security:

- The application must not reveal whether an email address belongs to an existing account.
- The same response message is displayed regardless of account existence.
- Repeated reset requests are rate-limited.
- Reset links can only be used by the intended email recipient.

### 5.5 Password Policy

Passwords must satisfy the following requirements:

- Minimum 8 characters
- At least one uppercase letter
- At least one lowercase letter
- At least one number
- At least one special character

## 6. Account Deletion and Recovery

### 6.1 Account Deletion

- Users can request account deletion.
- Re-authentication is required before deletion.
- Email + Password accounts require password confirmation.
- Google-only accounts require Google re-authentication.
- Explicit confirmation is required.
- The warning must explain that all Profiles and associated learning data will eventually be permanently deleted.

### 6.2 Grace Period

- Account deletion has a 30-day grace period.
- The account status changes to `PendingDeletion`.
- Normal login and learning access are disabled during this period.
- Account data and learning data are retained.
- The existing email address remains reserved during the grace period.

### 6.3 Account Recovery

- Users can restore their account within 30 days.
- The recovery flow allows the user to authenticate and choose to restore the account.
- All Profiles and learning data are restored unchanged.
- The account returns to `Active`.

### 6.4 Permanent Deletion

- A background process runs once per day.
- Accounts whose scheduled deletion date has passed are permanently deleted.
- All associated Profiles and learning data are permanently deleted.
- The deletion result is recorded.
- After permanent deletion, the email address can be used for a new account.

## 7. Authentication & Security

### 7.1 Authentication Technology

- ASP.NET Core Identity is used for account management.
- Cookie Authentication is used for the MVP.
- JWT authentication is not required for the MVP.
- Google Login uses external authentication support.

### 7.2 Remember Me

- Remember Me is available on the login screen.
- When disabled, a non-persistent session cookie is used.
- When enabled, a persistent cookie is used for up to 30 days.
- Sliding expiration extends the expiration period when the user is active.

### 7.3 Login Lockout

- Five consecutive failed password attempts trigger an account lockout.
- The account is locked for five minutes.
- Successful login resets the failed attempt count.

### 7.4 Logout

- Logout immediately expires the current device's authentication cookie.
- The user is redirected to the login screen.
- Other device sessions remain active.
- Global logout is not supported in the MVP.

### 7.5 Session Invalidation

| Event | Session Behavior |
|---|---|
| Password change | Keep current device; invalidate other devices |
| Password reset | Invalidate all devices |
| Email change | Invalidate all devices |
| Role change | Invalidate all devices |
| Account deactivation | Invalidate all devices |
| Logout | Invalidate current device only |

### 7.6 Concurrent Login

- Multiple devices can log in simultaneously.
- No device limit is enforced.
- Each device maintains its own active Profile.
- Device management is not included in the MVP.

### 7.7 Security Notifications

Email notifications are sent for:

- Login from a new device or browser
- Password change
- Password reset
- Email address change
- Account deletion request
- Account recovery

## 8. Roles and Permissions

### 8.1 Available Roles

The MVP supports three Roles:

- `User`
- `ContentEditor`
- `Admin`

Future Roles and concepts:

- `Teacher`
- `Organization`

These are excluded from the MVP.

### 8.2 Role Permissions

**User**

- Manage own account
- Manage own Profiles
- Access learning features
- View Published learning content

**ContentEditor**

- All general learning features available to User
- Create learning content
- Read learning content
- Update learning content
- Delete learning content
- Publish learning content
- Unpublish learning content

**Admin**

- All ContentEditor permissions
- User management
- Role management
- Account activation and deactivation
- System management
- Audit Log access

Admin and ContentEditor have the same content management permissions.

### 8.3 Role Assignment

- New accounts receive the `User` Role by default.
- Users cannot select Admin or ContentEditor during registration.
- The initial Admin account is created manually by the developer.
- Only Admin can assign or remove Admin and ContentEditor Roles.
- Users cannot change their own Roles.
- Role changes are recorded in Audit Logs.
- All sessions are invalidated after a Role change.

## 9. Admin Management

### 9.1 User Management Permissions

Admin can:

- View user lists and account details
- Activate or deactivate accounts
- View account lockout status
- Unlock accounts
- View Profile lists

Admin cannot:

- View user passwords
- Directly change user passwords

Permanent account deletion through the Admin interface is excluded from the MVP.

### 9.2 Account Deactivation

When an account is deactivated:

- The user cannot log in.
- All existing sessions are invalidated.
- Profiles and learning data are retained.
- Reactivating the account restores access to existing data.
- Activation and deactivation are recorded in Audit Logs.

### 9.3 ContentEditor Account Management

- Only Admin can assign or remove ContentEditor Roles.
- ContentEditor can use normal authentication methods.
- Deactivating a ContentEditor account invalidates all sessions.
- Existing content created by the ContentEditor is retained.
- Reactivating the account restores its previous content management permissions.
- Role and account status changes are recorded in Audit Logs.

### 9.4 Admin MFA

- Admin accounts require Multi-Factor Authentication.
- User and ContentEditor accounts do not require MFA in the MVP.
- Authenticator apps are supported.
- TOTP-based six-digit codes are used.
- Recovery codes are provided.
- Recovery codes are single-use.

### 9.5 MFA Enrollment and Recovery

- Admin must enroll an Authenticator app on the first login.
- Admin features are unavailable until MFA enrollment is completed.
- Changing an Authenticator requires existing MFA verification.
- New recovery codes can be generated.
- Generating new recovery codes invalidates all previous recovery codes.
- Another Admin can reset an Admin's MFA.
- If no other Admin exists, the developer can recover the account directly through the server.
- MFA reset actions are recorded in Audit Logs.

### 9.6 Last Admin Protection

- At least one active Admin account must always exist.
- The last active Admin cannot remove their own Admin Role.
- The last active Admin account cannot be deactivated or deleted.
- Changes are allowed only when another active Admin remains.

## 10. Audit Log

### 10.1 Purpose

Audit Logs record important administrative and content management activities for accountability and security.

### 10.2 Recorded Actions

- User Role changes
- User account activation and deactivation
- Profile deletion
- Learning content creation
- Learning content updates
- Learning content deletion
- Content Publish and Unpublish
- Permanent account deletion
- Admin MFA reset

### 10.3 Audit Log Fields

Each record contains:

- `Actor`: User who performed the action
- `Action`: Action performed
- `EntityType`: Type of affected entity
- `EntityId`: ID of the affected entity
- `Timestamp`: Time of the action
- `Details`: Relevant change information

### 10.4 Audit Log Permissions

- Admin can view all Audit Logs.
- ContentEditor cannot view Audit Logs.
- User cannot view Audit Logs.
- Audit Logs are generated automatically.
- Audit Logs cannot be modified or deleted through the application.

## 11. Authorization Rules

- Users can only access Profiles they own.
- Users cannot view, update, or delete another user's Profiles.
- Learning progress, quiz results, XP, achievements, and learning history are scoped to the selected Profile.
- The server must verify Profile ownership for every relevant request.
- The application must not trust a Profile ID supplied by the client without checking ownership.
- The selected Profile is maintained independently per device.
- Learning APIs use the currently selected Profile as the learning context.

## 12. Out of Scope for MVP

The following features are deferred:

- Teacher Role
- Organization and Organization Membership
- Student accounts separate from account owners
- Custom avatar uploads
- Google account unlinking
- Global logout
- Device management
- Device count limits
- Admin permanent deletion through the UI
- Admin MFA for roles other than Admin
- User-managed MFA for User and ContentEditor
- JWT authentication
- Refresh Token management

## 13. Implementation Notes

- Use ASP.NET Core Identity for account authentication and security features.
- Use Cookie Authentication for the MVP.
- Use Identity token providers for email confirmation and password reset.
- Integrate an email delivery service for verification, password reset, and security notifications.
- Use Google external authentication for Google Login.
- Enforce Profile ownership in server-side authorization.
- Enforce the maximum of five Profiles and minimum of one Profile through application business rules.
- Implement a background process for permanent account deletion.
- Ensure account deletion and related data deletion are handled consistently.
- Configure cookie security, CORS, and CSRF protection according to the final frontend and API hosting arrangement.
- Use Audit Logs for important administrative and content management operations.