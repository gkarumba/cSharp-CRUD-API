import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { AccountService, ProductService } from '@app/_services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    products = null;
    isDeleting = false;

    constructor(
        private accountService: AccountService,
        private productService: ProductService) {}

    ngOnInit() {
        this.productService.getAll()
            .pipe(first())
            .subscribe(products => this.products = products);
    }

    deleteProduct(id: string) {
        const user = this.products.find(x => x.id === id);
        if (user) {
            this.isDeleting = true;
        }
        this.productService.delete(id)
            .pipe(first())
            .subscribe(() => {
                this.products = this.products.filter(x => x.id !== id)
            });
    }
}