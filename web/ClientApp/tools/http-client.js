class HttpClient {
  constructor(basePath) {
    this.basePath = basePath;
  }

  get(path) {
    return fetch(this.basePath.concat(path))
      .then(response => response.json());
  }

  put(path, data) {
    const params = {
      method: "PUT",
      body: JSON.stringify(data),
      headers: new Headers({
        "Content-Type": "application/json"
      })
    };

    const uri = this.basePath.concat(path);
    return fetch(uri, params)
      .then(response => response.json());
  }

  delete(path) {
    const params = {
      method: "DELETE"
    };

    const uri = this.basePath.concat(path);
    return fetch(uri, params)
      .then(response => true);
  }
}

export default new HttpClient('/api/')