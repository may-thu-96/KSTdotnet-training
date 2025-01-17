
## Kpay Application

### Features

- **Mobile No** => Transfer
- **Id, FullName, MobileNo, Balance, Pin (000000)**
- **Bank** => Deposit / Withdraw

#### API Endpoints

1. **Deposit**
   - **Deposit API** => MobileNo, Balance (+) => 1000 + (-1000)

2. **Withdraw**
   - **Withdraw API** => MobileNo, Balance (-) => 1000 - (-1000)
   - Minimum balance 10,000 MMK

3. **Transfer**
   - **Transfer API**
     - FromMobileNo, ToMobileNo, Amount, Pin, Notes
     - FromMobile check
     - ToMobileNo check
     - FromMobileNo != ToMobileNo
     - Pin == 
     - Balance
     - FromMobileNo Balance (-)
     - ToMobileNo Balance (+)
     - Message (Complete)
     - Transaction History

4. **Balance**

### User Management

- **Create Wallet User**
- **Login**
- **Change Pin**
- **Phone No Change**
- **Forget Password**
- **Reset Password**
- **First Time Login**