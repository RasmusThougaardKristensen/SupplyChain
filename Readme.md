### Task description

You'll find two CSV files in this repository: one containing master data on LEGO sets and one containing information on stock levels in warehouses across the globe. All data is made up.

The task is to create a REST web service that handles data queries and allows a user to make inventory modifications. The design and structure of the API endpoints, and their request and response payloads, are left up to you.

Build the service using your preferred libraries and strongly-typed language (e.g. TypeScript, Go, Java, Rust).

### General guidelines
- Please create a GitHub repo for your solution, and make it accessible only to you and the users listed above.
- The delivery should include a README.md file with concise and complete setup instructions on how to build, execute and test your service.
- Please prepare a short walkthrough of your solution for the interview. We will have a talk about API design choices, trade-offs and library selection.
- Be ready to talk about where you made shortcuts for the sake of brevity, and what could have been included and addressed given more time.
- Updates to data do not need to be persisted between restarts of the service.

### API requirements
The API must be able to respond to 3 or more of the following queries and updates


**Core Data Access**
- Provide master data for a LEGO set given its unique SKU id.
- List warehouses with available stock for given SKUs
- Have the service calculate the weight of an order for shipping purposes, ie answer a query like *"Total weight of 3 items of SKU Y and one item of SKU Z"*.

**Inventory Management**
- Register shipments from and deliveries to a warehouse, e.g. *"50 boxes of SKU X arrived at warehouse Y"* or *"5 boxes of SKU X was shipped to customers from warehouse Y"*.
- Stock is sometimes transferred between warehouses to optimize warehouse usage capacity. Create an endpoint to register such a transfer.

**Business Operations**

- To provide data for a clearance sale, make it possible to query a warehouse for SKUs that have at most X units in stock. For bonus points, make it possible to filter by weight as well to get rid of the bigger sets first.
- Get a summary of a warehouse's stock. How many units in each category is currently held at the warehouse.

**Patterns I have used**
- Clean architecture
- Domain driven design(DDD)
- Value object / Strongly typed