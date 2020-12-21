using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class ToDoList
    {

        //check if authetincation and [authorize] attribute work  - checked if remains to hide the action if the userRole is not admin  ======= finished
        // ADD TO CART BUTTON HAVE TO MAKE IT WORK TO CHECK IF THE LIST WITH MY ORDERS WORKS. ===== finished
        //THE MAPPER SETS DATETIME NOW ON EVERY ORDER SO WE NEED TO FIX THAT
        // check if the cart is working correctly == works, but if you add existing product throws error
        // partial view for implementing invoice
        // admin to check on the users with full info
        //update product ne e iskoristeno trebe da se implementire ====== finished
        //delete funkcijata a povikave na httpget samo ====== finished
        // quantity add it in the modify product table ==== finished
        // update interface to the list products. ==== finished
        // the user wants to delete an item from the basket === finished
        //add picture to database and upload
        // if someone buys items we have to lower the quantity in database or if it cancels the order we have to add in the quantity.
        // sum for the products in the basket == finished
        //add quantity field in the product list
        // list all orders for admin and enter in eachone(you have to create a view that will be used for the user also).
        // validation if the user is correct but the password is wrong3 === finished
        

        // Orders part


        // how will it go down: 

        /* 1. user add's items in the cart that he wants to buy and places the order. 
         * 2. after finishing the order(user goes to payment), the app contacts the database to check if there is still quanity of the ordered products.
         * If everything is in there redirects him to payment details, else 
         * sends notification to the user of the items that do not exist and ask him if he wants to continue to the payment(if cart is not empty and there is still a product) or 
         * to the shopping list once again.
         



    */
    }
}
