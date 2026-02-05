**🍔 YumBlazor – Full-Stack E-Commerce Solution**
YumBlazor is a high-performance, end-to-end e-commerce platform designed for a seamless food-ordering experience. Built using the latest .NET 9 and Blazor Server, the application follows a robust architecture that balances server-side stability with rich, client-side interactivity.

**🚀 Tech Stack**
Frontend (Client Interface)
Blazor Server: Leveraged Razor components for a dynamic Single Page Application (SPA) experience.

Radzen UI Components: Integrated professional-grade Radzen controls for advanced data management (DataGrids, Gauges, and interactive forms).

Bootstrap 5: Used for a fully responsive, mobile-first design.

State Management: Implemented a custom SharedStateService with event-driven logic to synchronize cart counts across components in real-time.

**Backend (Server & Data)**

ASP.NET Core .NET 9: High-performance runtime for handling server logic.

Entity Framework Core: Used as an ORM for efficient database communication.

SQL Server: Relational database for persistent storage of products, categories, and orders.

Architecture: Implemented the Repository Pattern to ensure clean code, testability, and separation of concerns.

**Security & Payments**

ASP.NET Core Identity: Robust authentication and role-based authorization (Admin vs. Customer).

OAuth 2.0 (Google Login): Seamless external authentication integrated via Google Cloud Console.

Stripe API: Secure end-to-end payment processing including session creation, status verification, and webhook handling.

**🌟 Key Features**
1. Dynamic Product Management
Real-time search and category-based filtering.
Interactive product cards with special tags (e.g., Best Seller, Spicy).

2. Interactive Shopping Cart
Live quantity updates (+/-) without page refreshes.
Automatic cart persistence and cleanup post-purchase.

3. Professional Admin Dashboard
Built with Radzen DataGrid for complex order management.
Features like advanced filtering, sorting, and pagination.
Order lifecycle tracking (Pending → Ready for Pickup → Completed → Cancelled).

4. Secure Checkout Workflow
Dynamic Stripe Checkout sessions.
Automated email logic (placeholder) and order success redirects.

**🛠️ How to Run**
Clone the repository: git clone https://github.com/APNA_USER/YumBlazor.git
Update the connection string in appsettings.json.
Add your Stripe API Key and Google Client Secrets.
Run migrations: Update-Database.
Press F5 in Visual Studio!

**Conclusion**
This project demonstrates my ability to build Full-Stack applications from scratch—handling everything from database design and architectural patterns to UI polish and third-party API integrations.
