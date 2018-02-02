function randomTimeout() {
  const min = 1500;
  const max = 3000;

  return Math.floor(Math.random() * (max - min + 1)) + min;
}

class Api {

  getUsers() {
    return fetch("/api/users")
      .then(response => response.json())
      .catch(err => console.error(err));
  }

  saveUser(user) {
    const params = {
      method: "PUT",
      body: JSON.stringify(user),
      headers: new Headers({
        "Content-Type": "application/json"
      })
    };

    return fetch("/api/users", params)
      .then(response => response.json())
      .catch(err => console.error(err));
  }

  deleteUser(id) {
    const params = {
      method: "DELETE"
    };

    return fetch(`/api/users/${id}`, params)
      .then(() => true)
      .catch(() => false);
  }

  addGroup(group) {
    return new Promise(resolve => {
      const groups = JSON.parse(localStorage.getItem("groups") || "[]");
      groups.push(group);
      localStorage.setItem("groups", JSON.stringify(groups));

      resolve(group);
    });
  }

  getGroups() {
    return new Promise(resolve => {
      setTimeout(() => resolve(JSON.parse(localStorage.getItem("groups") || "[]")), randomTimeout());
    });
  }

  deleteGroup(id) {
    return new Promise(resolve => {
      let groups = JSON.parse(localStorage.getItem("groups"));
      const index = groups.findIndex(grp => grp.id === id);
      if (index === -1) {
        resolve(false);
      } else {
        setTimeout(() => {
          groups.splice(index, 1);
          localStorage.setItem("groups", JSON.stringify(groups));
          resolve(true);
        }, randomTimeout());
      }
    });
  }
}

const api = new Api();

export default api;
