# LoginEncryption
This project is a way for me to learn about encrypting passwords and storing them in a safer manner in my database.
And since this is more of a learning project this will be built using console application / xunit for testing purposes.



## ⚙️ What are my goals with this project?
- Allow for user registration.
-- Encrypt the password and store the hash in the database.
-- Allow one email to only signup once.
- Allow for user to login.
-- Compare the user trying to login with the "hashed" password in the database. 
-- Maybe play around with session IDs to further increase security?
- Allow for user to change their password
-- Allow for user to change their password, and re-hash this new password.
-- How to make sure that this is done properly? Have some verification process before?
- Allow users to delete their accounts