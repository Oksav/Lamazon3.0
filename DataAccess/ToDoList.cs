using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    class ToDoList
    {
        
        //check if authetincation and [authorize] attribute work  - checked if remains to hide the action if the userRole is not admin  ======= finished
        // ADD TO CART BUTTON HAVE TO MAKE IT WORK TO CHECK IF THE LIST WITH MY ORDERS WORKS.
        //THE MAPPER SETS DATETIME NOW ON EVERY ORDER SO WE NEED TO FIX THAT
        // check if the cart is working correctly
        // partial view for implementing invoice
        // admin to check on the users with full info
        //update product ne e iskoristeno trebe da se implementire ====== finished
        //delete funkcijata a povikave na httpget samo ====== finished
        // should add quantity to products and add it in the modify product table



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
