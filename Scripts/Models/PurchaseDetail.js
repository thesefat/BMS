

class PurchaseDetail {
    productId = 0;
    productName = "";
    qty = 0;
    unitPrice = 0;


    getLineTotal() {
        return (this.qty > 0 && this.unitPrice > 0) ? this.qty * this.unitPrice : 0;
    }
}